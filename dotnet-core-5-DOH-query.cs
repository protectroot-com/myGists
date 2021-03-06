using System;
using Makaretu.Dns;
// add the Makaretu.Dns.Unicast Nuget package.
namespace testing123 
{
    class Program
    {
        static void Main(string[] args)
        {
            //add the Makaretu.Dns.Unicast Nuget package.
            Console.WriteLine("starting..");
            var result = yeet();
            //it works!
        }
        public static async System.Threading.Tasks.Task yeet ()
        {
            var dns = new Makaretu.Dns.DohClient(); 
            //pick your doh url ---> github.com/curl/curl/wiki/DNS-over-HTTPS
            //using xfinity as dns over https server.
            dns.ServerUrl = "https://doh.xfinity.com/dns-query";
            
            //query for twitter IP
            var response = dns.QueryAsync("twitter.com", DnsType.A);
            Console.WriteLine(response.Result.Answers.Count);
            foreach (var item in response.Result.Answers)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
