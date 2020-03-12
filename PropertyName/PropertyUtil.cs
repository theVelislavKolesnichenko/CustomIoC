﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropertyName
{
    public static class PropertyUtil
    {
        public static string GetPropertyName<TObject>(this TObject type,
                                                       Expression<Func<TObject, object>> propertyRefExpr)
        {
            return GetPropertyNameCore(propertyRefExpr.Body);
        }

        public static string GetName<TObject>(Expression<Func<TObject, object>> propertyRefExpr)
        {
            return GetPropertyNameCore(propertyRefExpr.Body);
        }

        private static string GetPropertyNameCore(Expression propertyRefExpr)
        {
            if (propertyRefExpr == null)
                throw new ArgumentNullException("propertyRefExpr", "propertyRefExpr is null.");

            string value = propertyRefExpr.ToString();

            int posA = value.IndexOf('.');
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + 1;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
           


            MemberExpression memberExpr = propertyRefExpr as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyRefExpr as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    memberExpr = unaryExpr.Operand as MemberExpression;
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                return memberExpr.Expression.ToString();

            //throw new ArgumentException("No property reference expression was found.",
            //                 "propertyRefExpr");

            return value.Substring(adjustedPosA);
        }
    }

}
