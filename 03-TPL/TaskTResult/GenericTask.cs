using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TaskTResult
{
    class GenericTask
    {
        static void Main(string[] args)
        {
            Task<string> t1 = Task.Factory.StartNew<string>(
                () => GetPage("http://www.morganstanley.com")
            );
            Task<int> t2 = Task.FromResult<int>(42);

            Task.WaitAll(t1, t2);


            string result = t1.Result;
            Console.WriteLine(result.Substring(0, 400));
        }

        static string GetPage(string uri)
        {
            using (var client = new WebClient())
                return client.DownloadString(uri);
        }
    }
}
