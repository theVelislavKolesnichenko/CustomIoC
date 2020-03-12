using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyName
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            string propertyName0 = user.GetPropertyName(u => u.Email);
            string propertyName1 = user.GetPropertyName(u => u.Address.Streat);
            string propertyName2 = user.GetPropertyName(u => u.Address.Streat.Name);


            Console.WriteLine(propertyName0);
            Console.WriteLine(propertyName1);
            Console.WriteLine(propertyName2);

            Profile profile = new Profile();
            profile.User = new User(() => profile.User);

            user = profile.User;
            user.Address = new Address { Streat = new Streat { Name = "Name" } };

            Console.WriteLine(user.GetPropertyName(u => user.Email));
            Console.WriteLine(user.GetPropertyName(u => user.Address));
            Console.WriteLine(user.GetPropertyName(u => user.Address.Streat));
            Console.WriteLine(user.GetPropertyName(u => user.Address.Streat.Name));

            Console.ReadLine();
        }
    }
}
