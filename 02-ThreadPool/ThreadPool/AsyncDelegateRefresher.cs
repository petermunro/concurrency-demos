using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPool
{
    class AsyncDelegateRefresher
    {
        static void Main(string[] args)
        {
            Func<long, long, long> f = LongRunningTask;

            f.BeginInvoke(10, 100000, ResultHandler, f);
            Console.WriteLine("Continuing...");
            Console.ReadLine();
        }

        static long LongRunningTask(long lower, long upper)
        {
            System.Threading.Thread.Sleep(2000);
            return upper - lower;
        }

        static void ResultHandler(IAsyncResult iar)
        {
            Func<long, long, long> f = (Func<long, long, long>)iar.AsyncState;
            long result = f.EndInvoke(iar);
            Console.WriteLine(result);
        }
    }
}
