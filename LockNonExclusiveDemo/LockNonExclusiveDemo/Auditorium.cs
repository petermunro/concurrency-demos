using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LockNonExclusiveDemo
{
    class Auditorium
    {
        const int MAX_PEOPLE = 3;
        static SemaphoreSlim _sem = new SemaphoreSlim(MAX_PEOPLE);
        static void Main(string[] args)
        {
            for (int i=0; i < 5; i++)
            {
                new Thread(Enter).Start(i);
            }
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _sem.Wait();
            Console.WriteLine(id + " is in!");
            Thread.Sleep(100 * (int)id);
            Console.WriteLine(id + " is leaving");
            _sem.Release();
        }
    }
}
