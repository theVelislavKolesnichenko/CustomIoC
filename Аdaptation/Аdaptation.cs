using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL = StudentSystem.Data.Model;
using StudentSystem.Client.Model;
using Framework.DataAccess.State;
using Framework.Mapper;
using StudentSystem.Data;
using Framework.IoC.DependencyInjection;

using BLL = StudentSystem.BLL.Model;
using System.Linq.Expressions;

namespace Аdaptation
{

    public class Registration
    {
        static Container ct = null;

        private Registration()
        {
            ct = new Container(ContainerOptions.UseDefaultValue);
            ct.RegisterType<IStudentManager, MsSql>();
            //ct.RegisterType<IStudentManager, Test>();
        }

        public static Container Instance
        {
            get 
            {
                if (ct == null)
                {
                   new Registration();
                }
                return ct;
            }
        }
    }

    //ResultList => BLL.Student
    public interface IStudentManager
    {
        List<BLL.Student> GetAllStudents();
        BLL.Student GetStudent(int id);
    }

    public class MsSql : IStudentManager
    {
        public List<BLL.Student> GetAllStudents()
        {
            var students = StudentManager.Find();

            List<BLL.Student> resultList = new List<BLL.Student>();

            foreach (DAL.Student student in students)
            {
                resultList.Add(Mapper.Map<BLL.Student>(student));
            }

            return resultList;
        }
        
        public BLL.Student GetStudent(int id)
        {
            var student = StudentManager.Find(id);

            BLL.Student result = new BLL.Student();
            List<BLL.Course> courseResult = new List<BLL.Course>(); 

            result = Mapper.Map<BLL.Student>(student);

            foreach (DAL.Course course in student.Courses)
            {
                courseResult.Add(Mapper.Map<BLL.Course>(course));
            }

            result.recCourses = courseResult;

            return result;
        }

        public bool AddStudent(StudentSystem.BLL.Model.Student student)
        {
            var result = StudentManager.Add(new StudentSystem.Data.Model.Student
            { Age = student.Age, FirstName = student.FirstName, LastName = student.LastName});

            return result;
        }

        public List<BLL.Student> GetAllStudents(Expression<Func<StudentSystem.Data.Model.Student, bool>> filter = null, string includeProperties = "")
        {
            List<StudentSystem.Data.Model.Student> students = StudentManager.Find(filter);

            List<BLL.Student> resultList = new List<BLL.Student>();

            foreach (DAL.Student student in students)
            {
                resultList.Add(Mapper.Map<BLL.Student>(student));
            }

            return resultList;
        }
    }

    public class Test : IStudentManager
    {
        public List<BLL.Student> GetAllStudents()
        {
            List<DAL.Student> studentList = new List<DAL.Student>() 
            {
                new DAL.Student
                {
                    Id = 1,
                    FirstName = "Perar",
                    LastName = "Petrov",
                    Age = 24
                }
            };

            List<BLL.Student> resultList = new List<BLL.Student>();

            foreach (DAL.Student student in studentList)
            {
                resultList.Add(Mapper.Map<BLL.Student>(student));
            }

            return resultList;
        }


        public BLL.Student GetStudent(int id)
        {
            DAL.Student studentList =
                new DAL.Student
                {
                    FirstName = "Perar",
                    LastName = "Petrov",
                    Age = 24
                };

            BLL.Student resultList = Mapper.Map<BLL.Student>(studentList);

            resultList.recCourses = new List<BLL.Course>() 
            {
                new BLL.Course
                {
                    Id = 1,
                    Name = "Web",
                    Description = "Анотация"
                }
            };

            return resultList;
        }
    }

    public class AdapterStudent
    {
        private IStudentManager source;

        public AdapterStudent(IStudentManager powerSource)
        {
            this.source = powerSource;
        }

        public List<BLL.Student> GetAll()
        {
            return this.source.GetAllStudents();
        }

        public BLL.Student Get(int id)
        {
            return this.source.GetStudent(id);
        }
    }
}
