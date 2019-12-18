using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskCancellation
{
    //soft failure
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Task t1 = new Task(()=> {
                int i = 0;
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    Console.WriteLine($"{i++}");
                    Thread.Sleep(100);
                }
            },token);
            t1.Start();
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Main program has finished");
            Console.ReadKey();
        }
    }
}
