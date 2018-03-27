using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLDemo
{
    class Program
    {
        static void DoWorkItem()
        {
            Console.WriteLine("Running on the Thread Pool");
        }
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(DoWorkItem);
            Task t2 = Task.Factory.StartNew(() => Console.WriteLine("And with a lambda"));
            Console.WriteLine("t1 is completed: " + t1.IsCompleted);
            Console.WriteLine("t2 is completed: " + t2.IsCompleted);
            Task.WaitAll(t1, t2);

        }
    }
}
