using StudentSystem.BLL.Interface;
using StudentSystem.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Аdaptation;

namespace StudentSystem.BLL
{
    public class StudentLogic : IStudentLogic
    {
        public List<Student> GetStudents()
        {
            var conteiner = Registration.Instance;
            var laptop1 = conteiner.Resolve<AdapterStudent>();
            return laptop1.GetAll();
        }

        public Student GetStudent(int id)
        {
            var conteiner = Registration.Instance;
            var laptop1 = conteiner.Resolve<AdapterStudent>();
            return laptop1.Get(id);
        }
    }
}
