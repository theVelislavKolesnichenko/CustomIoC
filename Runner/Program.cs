using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Framework.IoC.ServiceLocator;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            // How to use our very simple Service Locator.
            var test = new SimpleCalc();
            
            
            //Console.WriteLine("Result before registering with Locator '{0}'", test.SomeNumber);

            // Register service with locator.
            Locator.SetInstance<ISimpleCalc>(test);

            test.SomeNumber = 17872;
            // Get instance from locator
            var instance = Locator.GetInstance<ISimpleCalc>();

            // Result
            Console.WriteLine("Result from Locator '{0}'", instance.SomeNumber);

            Console.ReadKey();
        }
    }
}
