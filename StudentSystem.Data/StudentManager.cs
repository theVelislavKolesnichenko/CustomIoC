using Framework.DataAccess.EntityFramework;
using Framework.DataAccess.EntityFramework.Migrations;
using Framework.DataAccess.Interface;
using Framework.DataAccess.State;
using StudentSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    public static class StudentManager
    {
        public static List<Student> Find()
        {
            List<Student> students = new List<Student>();
            using (IUnitOfWork unitOfWork = new EFUnitOfWork(new StudentSystemDbContext()))
            {
                Repository<Student> repository = new Repository<Student>(unitOfWork);
                students = repository.Get().ToList();
            }
            return students;
        }

        public static List<Student> Find(Expression<Func<Student, bool>> filter = null, string includeProperties = "")
        {
            List<Student> student = new List<Student>();

            using (IUnitOfWork unitOfWork = new EFUnitOfWork(new StudentSystemDbContext()))
            {
                Repository<Student> repository = new Repository<Student>(unitOfWork);
                student = repository.Get(filter, includeProperties).ToList();
            }

            return student;
        }

        public static Student Find(int id)
        {
            Student student = new Student();

            using (IUnitOfWork unitOfWork = new EFUnitOfWork(new StudentSystemDbContext()))
            {
                Repository<Student> repository = new Repository<Student>(unitOfWork);
                student = repository.Get(s => s.Id == id).SingleOrDefault();
            }

            return student;
        }

        public static bool Add(Student student)
        {
            bool success = false;
            using (IUnitOfWork unitOfWork = new EFUnitOfWork(new StudentSystemDbContext()))
            {
                Repository<Student> repository = new Repository<Student>(unitOfWork);
                student.UnitState = UnitState.Added;
                student = repository.Create(student);
                unitOfWork.Commit();
                success = true;
            }
            return success;
        }


    }
}
