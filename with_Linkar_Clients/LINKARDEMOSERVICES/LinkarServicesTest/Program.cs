using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LinkarServicesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "hello";
            int seconds = 5;

            //----WCF----
            Console.WriteLine("WCF CALL...");
            try
            {
                LinkarDemoWCF.Service1Client test = new LinkarDemoWCF.Service1Client();
                Console.WriteLine(test.GetData(text, seconds));
            }
            catch (Exception ex)
            {
                Console.WriteLine("WCF ERROR: " + ex.Message);
            }
            //-----------

            //----REST API----
            Console.WriteLine("REST API CALL...");
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50313/");
                    HttpResponseMessage res = client.GetAsync("api/values?text=" + text + "&seconds=" + seconds).Result;

                    if (res.IsSuccessStatusCode) 
                        Console.WriteLine(res.Content.ReadAsStringAsync().Result);
                    else
                        Console.WriteLine("REST API ERROR: " + res.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("REST API ERROR: " + ex.Message);
            }
            //-----------

            Console.ReadKey();
        }
    }
}
