namespace Convertor
{
    using System;
    using Framework.Mapper;
    using Framework.IoC.DependencyInjection;
    using System.Collections.Generic;
    using Framework.IoC.ServiceLocator;

    public static class Program
    {

        //public static T To<T>(this object text)
        //{
        //    return (T)Convert.ChangeType(text, typeof(T));
        //}

        //static void Main(string[] args)
        //{
        //    int val = "124".To<int>();
        //    double dbl = "124,5".To<double>();
        //    DateTime dd = "24-5-55".To<DateTime>();
        //    float value = 19.4.To<float>();
        //    //double test = (double)Convert.ChangeType(19.4, typeof(double));

        //    Console.WriteLine("{0}\n{1}\n{2}\n{3}", val, dbl, dd, value);
        //}

        public class User
        {
            public string name { get; set; }
            public string family { get; set; }
            public int age { get; set; }
        }

        public class SearchResult
        {
            [Mapper("name")]
            public string Title { get; set; }
            [Mapper("family")]
            public string SubTitle { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            SearchResult obj = new SearchResult();
            obj.Title = "Peter";
            obj.SubTitle = "Petrov";
            obj.Age = 12;

            User user = Mapper.Map<SearchResult, User>(obj);

            Console.WriteLine("{0} {1} {2}", user.name, user.family, user.age);
        }

        //public interface IStudentManager
        //{
        //    List<SearchResult> GetAllStudents();
        //}

        //public class Repository : IStudentManager
        //{
        //    public List<SearchResult> GetAllStudents()
        //    {
        //        List<SearchResult> list = new List<SearchResult>();
        //        list.Add(
        //            new SearchResult
        //            {
        //                Age = 15,
        //                SubTitle = "Computer",
        //                Title = "Program"
        //            });

        //        return list;
        //    }
        //}

        //public class SearchResult
        //{
        //    public string Title { get; set; }
        //    public string SubTitle { get; set; }
        //    public int Age { get; set; }
        //}

        //public class AdapterStudent
        //{
        //    private IStudentManager source;

        //    public AdapterStudent(IStudentManager powerSource)
        //    {
        //        this.source = powerSource;
        //    }

        //    public List<SearchResult> GetAll()
        //    {
        //        return this.source.GetAllStudents();
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    var ct = new Container(ContainerOptions.UseDefaultValue);
        //    ct.RegisterType<IStudentManager, Repository>();
        //    var laptop1 = ct.Resolve<AdapterStudent>();
        //    List<SearchResult> resultList = laptop1.GetAll();
        //}

        //public interface ISimpleCalc
        //{
        //    int SomeNumber { get; }
        //}

        //public class SimpleCalc : ISimpleCalc
        //{
        //    public int SomeNumber { get {return 17872; } }
        //}

        //static void Main(string[] args)
        //{
        //    var test = new SimpleCalc();
        //    Console.WriteLine("Result before registering with Locator '{0}'", test.SomeNumber);
        //    // Register service with locator.
        //    Locator.SetInstance<ISimpleCalc>(test);
        //    // Get instance from locator
        //    var instance = Locator.GetInstance<ISimpleCalc>();
        //    // Result
        //    Console.WriteLine("Result from Locator '{0}'", instance.SomeNumber);
        //}

        //public interface ISimpleCalc
        //{
        //    int SomeNumber { get; }
        //}

        //public class SimpleCalc : ISimpleCalc
        //{
        //    public int SomeNumber { get { return 17872; } }
        //}

        //static void Main(string[] args)
        //{
        //    var test = new SimpleCalc();
        //    Console.WriteLine("Result before registering with Locator '{0}'", test.SomeNumber);
        //    // Register service with locator.
        //    Locator.SetInstance<ISimpleCalc>(test);
        //    // Get instance from locator
        //    var instance = Locator.GetInstance<ISimpleCalc>();
        //    // Result
        //    Console.WriteLine("Result from Locator '{0}'", instance.SomeNumber);
        //}
    }
}
