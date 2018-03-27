using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_QueueUserWorkItem
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(DoStuff);
            Console.ReadLine();
        }

        static void DoStuff(object data)
        {
            Console.WriteLine("Running on the Thread Pool");
        }
    }
}
