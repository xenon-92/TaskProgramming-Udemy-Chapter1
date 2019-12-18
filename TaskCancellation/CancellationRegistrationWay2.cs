using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskCancellation
{
    class CancellationRegistrationWay2
    {
        static void Main()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Task t1 = new Task(()=> {
                int i = 0;
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine(i++);
                    Thread.Sleep(200);
                }
            },token);

            token.Register(()=> {
                Console.WriteLine("Cancellation token registered(1)........");
            });
            Task.Factory.StartNew(()=> {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Cancellation token registered(2)........");
            });
            t1.Start();
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Main program has finsihed working.....");
            Console.ReadKey();
        }
    }
}
