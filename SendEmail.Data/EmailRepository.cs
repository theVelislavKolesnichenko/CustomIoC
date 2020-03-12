using SendEmail.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SendEmail.Data.Interface;

namespace SendEmail.Data
{
    public class EmailRepository : IEmailRepository
    {
        public List<User> GetPoints()
        {
            var users = new List<User>();

            var file = new StreamReader(@"D:\\DevRepository\\VisualStudio\\ProgrammingBasics\\Framework\\SendEmail.Data\\DataBase0.1.txt");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(',');
                var id = int.Parse(parts[0]);
                var name = parts[1];
                var email = parts[2];

                var user = new User 
                { 
                  Id = id, 
                  Name = name,
                  Email = email
                };

                users.Add(user);
            }

            file.Close();

            return users;
        }
    }
}
