using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WaitAll_WaitAny
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var dt = DateTime.Now;
            Task t1 = new Task(()=> {
                Console.WriteLine("starting of five seconds work..");
                Thread.Sleep(5000);
                Console.WriteLine("ending of five seconds work..");
            },token);
            Task t2 = Task.Factory.StartNew(()=> {
                Console.WriteLine("starting of 3 seconds work..");
                Thread.Sleep(3000);
                Console.WriteLine("ending of 3 seconds work..");
            },token);
            t1.Start();
            //Task.WaitAll(t1,t2);
            //Task.WaitAny(t1,t2);
            //**************
            Console.ReadKey();
            cts.Cancel();
            Task.WaitAll(new[] { t1,t2},2000/*,token*/);
            var dt2 = DateTime.Now;
            Console.WriteLine(dt2-dt);
            Console.WriteLine("Main program has finished...");
            Console.ReadKey();
        }
    }
}
