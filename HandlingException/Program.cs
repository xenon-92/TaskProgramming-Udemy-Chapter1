using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingException
{
    //handling exception
    class Program
    {
        static void Main(string[] args)
        {
            //The program has soft exception, the program does not terminate
            //but the same program, terminates when the two tasks are kept inside WaitAll(t1,t2);
            Task t1 = Task.Factory.StartNew(()=> {
                throw new AccessViolationException("access violation") { Source ="t1"};
            });
            Task t2 = Task.Factory.StartNew(() => {
                throw new InvalidOperationException("operation violation") { Source = "t2" };
            });
            Console.WriteLine("Main program has finished executing.....");
            Console.ReadKey();
        }
    }
}
