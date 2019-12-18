using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingException
{
    class HandlingException_Exception2
    {
        static void Main()
        {
            try
            {
                Task t1 = Task.Factory.StartNew(() => {
                    throw new InvalidOperationException("Invalid operation") { Source = "t1" };
                });
                Task t2 = Task.Factory.StartNew(() => {
                    throw new AccessViolationException("Invalid access") { Source = "t2" };
                });
                Task.WaitAll(t1,t2);
            }
            catch (AggregateException ae)
            {

                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine(e.GetType()+"from "+e.Source);
                }
            }
            Console.WriteLine("Main program has finsihed executing.....");
            Console.ReadKey();
        }
    }
}
