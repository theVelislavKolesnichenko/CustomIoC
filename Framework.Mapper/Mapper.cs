namespace Framework.Mapper
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Reflection;
    using System.Globalization;

    public static class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource Source)
            where TSource : class
            where TDestination : class, new()
        {
            return Map<TDestination>(Source);
        }

        public static TDestination Map<TDestination>(object Source)
            where TDestination : class, new()
        {
            if (Source == null)
                throw new ArgumentNullException("Mapping type cannot be null");

            Type SourceType = Source.GetType();
            Type DestinationType = typeof(TDestination);
            TDestination Destination = new TDestination();

            MemberInfo[] DestinationProperties = DestinationType.GetProperties();
            MemberInfo[] DestinationFieldsM = DestinationType.GetFields();

            MemberInfo[] SourcePropertiesM = SourceType.GetProperties();
            MemberInfo[] SourceFieldsM = SourceType.GetFields();

            MemberInfo[] DestinationMember = DestinationProperties.Concat(DestinationFieldsM).ToArray();
            MemberInfo[] SourceMember = SourcePropertiesM.Concat(SourceFieldsM).ToArray();

            var equalMember = from td in DestinationMember
                              join fd1 in SourceMember
                              on td.CustumName().ToLower() equals fd1.CustumName().ToLower()
                              select new
                              {
                                  ToProperty = (td),
                                  FromProperty = (fd1)
                              };

            foreach (var prop in equalMember)
            {
                object fromValue = null;
                if (((MemberInfo)prop.FromProperty).MemberType == MemberTypes.Property)
                {
                    PropertyInfo property = (PropertyInfo)prop.FromProperty;
                    fromValue = property.GetValue(Source, null);
                }
                else if (((MemberInfo)prop.FromProperty).MemberType == MemberTypes.Field)
                {
                    FieldInfo field = (FieldInfo)prop.FromProperty;
                    fromValue = field.GetValue(Source);
                }

                if (((MemberInfo)prop.ToProperty).MemberType == MemberTypes.Property)
                {
                    PropertyInfo property = (PropertyInfo)prop.ToProperty;
                    property.SetValue(Destination, fromValue.To(property.PropertyType), null);
                }
                else if (((MemberInfo)prop.ToProperty).MemberType == MemberTypes.Field)
                {
                    FieldInfo field = (FieldInfo)prop.ToProperty;
                    field.SetValue(Destination, fromValue.To(field.FieldType));
                }
            }

            return Destination;
        }

        private static string CustumName(this MemberInfo type)
        {
            object[] attributes = type.GetCustomAttributes(typeof(MapperAttribute), true);

            if (attributes.Length != 0)
            {
                foreach (object attribute in attributes)
                {
                    MapperAttribute mapperAttribute = attribute as MapperAttribute;

                    if (mapperAttribute != null)
                        return mapperAttribute.Name;
                    else
                        throw new ArgumentNullException("MapperAttribute is null");
                }
            }
            return type.Name;
        }

        public static T To<T>(this object text)
        {
            return (T)Convert.ChangeType(text, typeof(T));
        }

        private static object To(this object vvalue, Type vtype)
        {

            var type = Type.GetTypeCode(vtype);

            string value = vvalue.ToString();

            if (string.IsNullOrEmpty(value) && type != TypeCode.String && type != TypeCode.Object)
                throw new ArgumentNullException("Convert type cannot be null");

            switch (type)
            {
                case TypeCode.String:
                case TypeCode.Object:
                    return value;

                case TypeCode.Boolean:
                    bool boolean;
                    bool.TryParse(value, out boolean);
                    return boolean;

                case TypeCode.Char:
                    return value[0];

                case TypeCode.SByte:
                    return sbyte.Parse(value, NumberStyles.Integer, Thread.CurrentThread.CurrentCulture);
                case TypeCode.Byte:
                    return byte.Parse(value, NumberStyles.Integer, Thread.CurrentThread.CurrentCulture);
                case TypeCode.Int16:
                    return short.Parse(value, NumberStyles.Integer, Thread.CurrentThread.CurrentCulture);
                case TypeCode.UInt16:
                    return ushort.Parse(value, NumberStyles.Integer, Thread.CurrentThread.CurrentCulture);
                case TypeCode.Int32:
                    return int.Parse(value, NumberStyles.Integer, Thread.CurrentThread.CurrentCulture);
                case TypeCode.UInt32:
                    return uint.Parse(value, NumberStyles.Integer, Thread.CurrentThread.CurrentCulture);
                case TypeCode.Int64:
                    return long.Parse(value, NumberStyles.Integer, Thread.CurrentThread.CurrentCulture);
                case TypeCode.UInt64:
                    return long.Parse(value, NumberStyles.Integer, Thread.CurrentThread.CurrentCulture);

                case TypeCode.Single:
                    return float.Parse(value, NumberStyles.Float | NumberStyles.AllowThousands, Thread.CurrentThread.CurrentCulture);
                case TypeCode.Double:
                    return double.Parse(value, NumberStyles.Float | NumberStyles.AllowThousands, Thread.CurrentThread.CurrentCulture);
                case TypeCode.Decimal:
                    return decimal.Parse(value, NumberStyles.Number, Thread.CurrentThread.CurrentCulture);

                case TypeCode.DateTime:
                    return DateTime.Parse(value, Thread.CurrentThread.CurrentCulture);
            }

            throw new ArgumentNullException("Convert type cannot be null");
        }
    }
}
