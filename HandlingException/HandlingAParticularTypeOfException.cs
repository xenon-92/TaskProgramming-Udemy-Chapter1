using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingException
{
    //this will throw a hard error because we have handle a part of exception [InvalidOperationException]
    //coming from aggregate exception and not the [AccessViolationException]
    class HandlingAParticularTypeOfException
    {
        static void Main()
        {
            test();
            Console.WriteLine("Main program has finsihed executing.....");
            Console.ReadKey();
        }

        private static void test()
        {
            try
            {
                Task t1 = Task.Factory.StartNew(() => {
                    throw new InvalidOperationException("invalid operation") { Source = "t1" };
                });
                Task t2 = Task.Factory.StartNew(() => {
                    throw new AccessViolationException("access violation operation") { Source = "t2" };
                });
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ae)
            {

                ae.Handle(e=> {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op!");
                        return true;//we have handled invalid operation exception
                    }
                    return false;
                });
            }
        }
    }
}
