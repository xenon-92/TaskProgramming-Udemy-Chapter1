using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WaitingForTimeToPass
{
    class Program
    {
        //waiting for a definite time to pass, through cancellation token's wait handle
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Task t = new Task(()=> {
                Console.WriteLine("Waiting inside for 5 seconds, press any key to disarm");
                bool cancelled =  token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled?"disarmed":"boom!!");
            },token);
            t.Start();
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Main program has finished running.....");
            Console.ReadKey();
        }
    }
}
