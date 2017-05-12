using System;
using System.BrowserHistory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<URL> urls = BrowserHistory.GetFirefoxHistory();

            foreach(var url in urls)
            {
                Console.WriteLine(url.title);
            }

            Console.ReadKey();
        }
    }
}
