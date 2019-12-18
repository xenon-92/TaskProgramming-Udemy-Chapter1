using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => { UnitOfWork('|'); });
            Task t = new Task(() => AnotherUnitOfWork(5));
            t.Start();
            UnitOfWork('*');
            Console.WriteLine("Main program has ended...");
            Console.ReadKey();
        }
        static void UnitOfWork(char c)
        {
            int i = 1000;
            while (i-->0)
            {
                Console.Write(c);
            }
        }
        static void AnotherUnitOfWork(int j)
        {
            int k = 1000;
            while (k-->0)
            {
                Console.Write(j);
            }
        }
    }
}
