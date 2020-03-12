using StudentSystem.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.BLL.Interface
{
    public interface IStudentLogic
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
    }
}
