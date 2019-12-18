using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskCancellation
{
    class CompositeTokenSrc
    {
        static void Main()
        {
            var cts1 = new CancellationTokenSource();
            var cts2 = new CancellationTokenSource();
            var cts3 = new CancellationTokenSource();
            var cascaded = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token, cts3.Token);
            Task t1 = new Task(()=> {
                int i = 0;
                while (true)
                {
                    cascaded.Token.ThrowIfCancellationRequested();
                    Console.WriteLine(i++);
                    Thread.Sleep(200);
                }
            },cascaded.Token);
            t1.Start();
            cascaded.Token.Register(() => {
                Console.WriteLine("Cascaded token got cancelled(1).....");
            });
            Task.Factory.StartNew(()=> {
                cascaded.Token.WaitHandle.WaitOne();
                Console.WriteLine("Cascaded token got cancelled(2).....");
            });
            Console.ReadKey();
            cascaded.Cancel();
            Console.WriteLine("Main program is finished....");
            Console.ReadKey();
        }
    }
}
