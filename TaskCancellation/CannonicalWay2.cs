using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskCancellation
{
    class CannonicalWay2
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
                    Console.WriteLine($"{i++}");
                }
            },token);
            t1.Start();
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Main program has finished....");
            Console.ReadKey();
        }
    }
}
