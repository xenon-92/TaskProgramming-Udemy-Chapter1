using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskCancellation
{
    class CancellationTokenRegistration
    {
        static void Main()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Task t1 = new Task(()=> {
                int j = 0;
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine(j++);
                    Thread.Sleep(100);
                }
            },token);
            t1.Start();
            token.Register(()=> {
                Console.WriteLine("cancellation has been done.....");
            });
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Main program has finished running.....");
            Console.ReadKey();
        }
    }
}
