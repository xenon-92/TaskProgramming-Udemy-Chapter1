using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingException
{
    class Exception2
    {
        static void Main()
        {
            Task t1 = Task.Factory.StartNew(()=> {
                throw new AccessViolationException() { Source = "t1" };
            });
            Task t2 = Task.Factory.StartNew(() => {
                throw new InvalidOperationException() { Source = "t2" };
            });
            Task.WaitAll(t1,t2);
            Console.WriteLine("Main program has finsihed running.......");
            Console.ReadKey();
        }
    }
}
