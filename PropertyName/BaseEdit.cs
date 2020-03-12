using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropertyName
{
    public class BaseEdit
    {
        private string conteiner;

        public BaseEdit() { }

        public BaseEdit(Expression<Func<object>> propertyRefExpr)
        {
            conteiner = After(GetPropertyPathCore(propertyRefExpr.Body), ").");
        }

        private string GetPropertyPathCore(Expression propertyRefExpr)
        {
            if (propertyRefExpr == null)
                throw new ArgumentNullException("propertyRefExpr", "propertyRefExpr is null.");

            string value = string.Empty;

            MemberExpression memberExpr = propertyRefExpr as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyRefExpr as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    memberExpr = unaryExpr.Operand as MemberExpression;
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                value = memberExpr.Expression.ToString();
            }

            return value;
        }

        private string After(string value, string ch)
        {
            int posA = value.IndexOf(ch);
            if (posA > -1)
            {
                int adjustedPosA = posA + 2;
                if (adjustedPosA < value.Length)
                {
                    value = value.Substring(adjustedPosA);
                }
            }
            return value;
        }

        public string GetPropertyName(Expression<Func<BaseEdit, object>> propertyRefExpr)
        {
            return string.Format("{0}.{1}", conteiner, GetPropertyPathCore(propertyRefExpr.Body));
        }

    }
}

