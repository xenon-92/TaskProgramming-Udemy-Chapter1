using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_programming
{
    class ReturningResultFromATask
    {
        static void Main()
        {
            //Task<int> t = new Task<int>(()=> {return UnitOfWork("Length"); });
            //Task<int> t1 = new Task<int>(()=>  UnitOfWork("Lengthy"));
            //t1.Start();t.Start();
            //Task<int> fact = Task<int>.Factory.StartNew(()=> { return UnitOfWork("sam"); });
            //Console.WriteLine(t.Result);
            //Console.WriteLine(t1.Result);
            //Console.WriteLine(fact.Result);

            Task<int> tObj = new Task<int>(AnotherUnitOfWork,42);
            tObj.Start();
            Task<int> tObj2 = new Task<int>(AnotherUnitOfWork,"Lengthy");
            tObj2.Start();
            Task<int> tx = Task<int>.Factory.StartNew(AnotherUnitOfWork,458999999);
            Console.WriteLine(tObj.Result);
            Console.WriteLine(tObj2.Result);
            Console.WriteLine(tx.Result);
            Console.WriteLine("Main program has ended......");
            Console.ReadKey();
        }
        static int UnitOfWork(string str)
        {
            Console.WriteLine($"Task with {Task.CurrentId} is executing {str}");
            return str.Length;
        }
        static int AnotherUnitOfWork(object str)
        {
            Console.WriteLine($"Task with {Task.CurrentId} is executing {str}");
            return str.ToString().Length;
        }
    }
}
