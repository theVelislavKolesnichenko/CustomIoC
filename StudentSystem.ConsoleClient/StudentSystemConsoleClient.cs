using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DataAccess.State;

using StudentSystem.Client.Model;
using Framework.IoC.DependencyInjection;
using Аdaptation;
using Framework.IoC.ServiceLocator;
using StudentSystem.BLL.Interface;
using Framework.Mapper;

namespace StudentSystem.ConsoleClient
{
    class StudentSystemConsoleClient
    {
        static void Main(string[] args)
        {
            //List<Student> students = StudentSystem.Data.StudentManager.Find();

            Аdaptation.Test t = new Аdaptation.Test();

            List<StudentSystem.BLL.Model.Student> resultList = t.GetAllStudents();

            //var ct = new Container(ContainerOptions.UseDefaultValue);
            //ct.RegisterType<IStudentManager, MsSql>();
            //ct.RegisterType<IStudentManager, Test>();

            //var conteiner = Registration.Instance;
            //var laptop1 = conteiner.Resolve<AdapterStudent>();
            //List<ResultList> resultList = laptop1.GetAll();

            ////UIAdapter.Adapter adapter = new UIAdapter.Adapter();
            ////var instance = Locator.GetInstance<IStudentLogic>();
            ////var result = instance.GetStudents();

            ////List<ResultList> resultList = new List<ResultList>();

            ////foreach (StudentSystem.BLL.Model.Student student in result)
            ////{
            ////    resultList.Add(Mapper.Map<ResultList>(student));
            ////}

            ////foreach (ResultList resultListItom in resultList)
            ////{
            ////    Console.WriteLine("ID:{0}\nFirstName:{1}\nLastName:{2}\nAge:{3}",
            ////        resultListItom.Id,
            ////        resultListItom.Title,
            ////        resultListItom.SubTitle,
            ////        resultListItom.Age);
            ////}

            foreach (StudentSystem.BLL.Model.Student resultListItom in resultList)
            {
                Console.WriteLine("ID:{0}\nFirstName:{1}\nLastName:{2}\nAge:{3}",
                    resultListItom.Id,
                    resultListItom.FirstName,
                    resultListItom.LastName,
                    resultListItom.Age);
            }

            //Аdaptation.MsSql ms = new Аdaptation.MsSql();
            //ms.AddStudent(new StudentSystem.BLL.Model.Student { Age = 20, FirstName = "FirstName_1", LastName = "LastName_1" });
        }
    }
}
