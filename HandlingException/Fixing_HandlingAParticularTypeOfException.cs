using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingException
{
    class Fixing_HandlingAParticularTypeOfException
    {
        static void Main()
        {
            try
            {
                Test();
            }
            catch (AggregateException ae)
            {

                //foreach (var e in ae.InnerExceptions)
                //{
                //    Console.WriteLine(e.GetType()+"..........."+e.Source);
                //}
                
                //-------------------or can be done in this way------------------
                ae.Handle(e=> {
                    if (e is AccessViolationException)
                    {
                        Console.WriteLine(e.GetType() + ":::::::::"+e.Source);
                        return true;
                    }
                    return false;
                });
            }
            Console.WriteLine("Main program has finished executing......");
            Console.ReadKey();
        }

        private static void Test()
        {
            try
            {
                Task t1 = Task.Factory.StartNew(() => {
                    throw new InvalidOperationException("Invalid operation") { Source = "t1" };
                });
                Task t2 = Task.Factory.StartNew(() => {
                    throw new AccessViolationException("access violation") { Source = "t2" };
                });
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ae)
            {
                // Summary:
                //     Invokes a handler on each System.Exception contained by this System.AggregateException.
                //
                // Parameters:
                //   predicate:
                //     The predicate to execute for each exception. The predicate accepts as an argument
                //     the System.Exception to be processed and returns a Boolean to indicate whether
                //     the exception was handled.
                //
                // Exceptions:
                //   T:System.ArgumentNullException:
                //     The predicate argument is null.
                //
                //   T:System.AggregateException:
                //     An exception contained by this System.AggregateException was not handled.
                ae.Handle(e=> {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op!!");
                        return true;
                    }
                    return false;
                });
            }
        }
    }
}
