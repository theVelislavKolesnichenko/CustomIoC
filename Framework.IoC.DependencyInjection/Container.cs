namespace Framework.IoC.DependencyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Container
    {
        private IDictionary<Type, Type> dependencies;
        private ContainerOptions options;
        private const ContainerOptions defaultOptions = ContainerOptions.None;

        private IDictionary<Type, List<Dependency>> dep;
        private IDictionary<Type, object> depobject = new Dictionary<Type, object>();


        public Container()
            : this(defaultOptions)
        {
        }

        public Container(ContainerOptions options)
        {
            this.options = options;
            this.dependencies = new Dictionary<Type, Type>();
            this.dep = new Dictionary<Type, List<Dependency>>();
        }

        public void RegisterType<TDependencyType, TResolveType>()
            where TDependencyType : class
            where TResolveType : class
        {
            this.dependencies.Add(typeof(TDependencyType), typeof(TResolveType));
            this.Add(typeof(TResolveType));
        }

        public T Resolve<T>() where T : class
        {
            //var classType = typeof(T);
            
            //var classType = (type == null) ? 
            //    this.dependencies.ContainsKey(typeof(T)) ? 
            //        this.dependencies[typeof(T)] : 
            //        typeof(T) :
            //    type;

            var classType = this.dependencies.ContainsKey(typeof(T)) ? 
                    this.dependencies[typeof(T)] : 
                    typeof(T);
            
            var constructors = classType
                .GetConstructors()
                // create a smarter way of choosing a constructor
                // maybe using enum flagз
                .OrderByDescending(x => x.GetParameters().Count());

            if (!constructors.Any())
            {
                throw new ArgumentException("The class to be resolved does not have any public constructors!");
            }

            foreach (var constructor in constructors)
            {
                // get the constructor parameters
                var parameters = constructor.GetParameters();

                // if the constructor has no parameters - instantiate the object and return it;
                if (parameters.Length == 0)
                {
                    //var result = Activator.CreateInstance<T>();
                    object result = Activator.CreateInstance(classType);
                    return (T)result;
                }
                else
                {
                    var parameterObjects = new List<object>();

                    foreach (var parameter in parameters)
                    {
                        var parameterType = parameter.ParameterType;

                        if (this.options.HasFlag(ContainerOptions.UseDefaultValue))
                        {
                            if (parameter.HasDefaultValue)
                            {
                                // using default value
                                var res = Convert.ChangeType(parameter.DefaultValue, parameterType);
                                parameterObjects.Add(res);
                                continue;
                            }
                        }

                        if (parameterType.IsAbstract || parameterType.IsInterface)
                        {
                            var concreteObjectType = this.dependencies[parameterType];
                            var method =
                                typeof(Container)
                                    .GetMethod("Resolve")
                                    .MakeGenericMethod(concreteObjectType);

                            //var obj = this.Resolve<T>(concreteObjectType); 
                            var obj = method.Invoke(this, null);

                            parameterObjects.Add(obj);
                        }
                        else if (parameterType.IsPrimitive || parameterType.GetConstructors().Any(x => !x.GetParameters().Any()))
                        {
                            var obj = Activator.CreateInstance(parameterType);
                            parameterObjects.Add(obj);
                        }
                    }

                    if (parameterObjects.Count != constructor.GetParameters().Length)
                    {
                        continue;
                    }

                    var createdObject = (T)Activator.CreateInstance(classType, parameterObjects.ToArray());
                    return createdObject;
                }
            }

            throw new Exception("Could not resolve the dependency");
        }

        public void Add(Type classType) 
        {
            var constructors = classType.GetConstructors();
            
            List<Dependency> depes = new List<Dependency>();
            
            foreach (var constructor in constructors)
            {
                Dependency depe = new Dependency();
                depe.Constructor = constructor;
                depe.Parameters = constructor.GetParameters();
                depes.Add(depe);
            }

            this.dep.Add(classType, depes);
        }

        public void Print() 
        {
            foreach (var depen in this.dep)
            {
                Console.WriteLine("{0}", depen.Key);

                foreach (var value in depen.Value)
                {
                    Console.WriteLine("{0}", value.Constructor.Name);

                    foreach (var value0 in value.Parameters)
                    {
                        Console.WriteLine("{0}", value0.Name);
                    }
                }
            }
        }

        public T Readed<T>(List<Dependency> ds) where T : class
        {
            List<Dependency> s = ds.Where(d => d.Parameters.Length == 0).ToList();

            Type classType = typeof(T);

            foreach (var ss in s)
            {
                Console.WriteLine(ss.Parameters);

                object result = Activator.CreateInstance(classType);
                //return (T)result;
            }

            var df = dep.Where(e => e.Value.Any(f => f.Parameters.LongLength == 0));

            foreach (var f in df)
            {
                var parameterObjects = new List<object>();

                foreach (var ff in f.Value)
                {
                    Console.WriteLine(ff.Parameters);

                    //var obj = Activator.CreateInstance(ff.Parameters.First());

                    //parameterObjects.Add(obj);
                }


                var createdObject = (T)Activator.CreateInstance(classType, parameterObjects.ToArray());

                depobject.Add(f.Key, createdObject);
            }

            return null;
        }

        public void Readedd()
        {
            foreach (var d in dep)
            {
                var method =
                    typeof(Container)
                        .GetMethod("Readed");

                var type = d.Key;

                var mm = method.MakeGenericMethod(type);

                var obj = mm.Invoke(this, new object[] { d.Value });
            }
        }

        public bool defaultes(ParameterInfo[] d)
        {
            if (d != null)
                return false;
            else
                return true;
        }
    }
}
