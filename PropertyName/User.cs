using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PropertyName
{
    public class User : BaseEdit
    {
        public User(Expression<Func<object>> propertyRefExpr) : base(propertyRefExpr) { }

        public User() { }

        public string Email { get; set; }
        public Address Address { get; set;}
    }

    public class Address
    {
        public Streat Streat { get; set; }
    }

    public class Streat
    {
        public string Name { get; set; }
    }
}
