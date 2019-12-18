using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_programming
{
    class OtherWayOfStartingTask_Object
    {
        static void Main()
        {
            Task.Factory.StartNew(UnitOfWork,'|');
            Task t = new Task(AnotherUnitOfWork,"SAM");
            t.Start();
            UnitOfWork(42);
            Console.WriteLine("Main program has ended...");
            Console.ReadKey();
        }
        static void UnitOfWork(object o)
        {
            int k = 1000;
            while (k-->0)
            {
                Console.Write(o);
            }
        }
        static void AnotherUnitOfWork(object o)
        {
            int k = 1000;
            while (k-- > 0)
            {
                Console.Write(o);
            }
        }
    }
}
