using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace Currency_Exchanger_app
{
    class Program
    {
        public class CurrencyExchange
        {
           
            public double timestamp{ get; set; }
            public string Base { get; set; }
            public Dictionary<object, object> rates { get; set; }  
        }

       

        static void Main(string[] args)
        {
            using(var webs =new  WebClient()){
                try
                {
                    

                    var OpenExchange = webs.DownloadString("https://openexchangerates.org/api/latest.json?app_id=c6e479aeb7b34e3bab041d8c0772b6ba");
                    var Deserializenw = JsonConvert.DeserializeObject<CurrencyExchange>(OpenExchange);

                    // time
                    double ts = Deserializenw.timestamp;
                    DateTime dt = new DateTime(1970,1,1,0,0,0,0).AddSeconds(ts).ToLocalTime();
                    string formatDate = dt.ToString("dd-mm-yyyy");

                    Console.WriteLine("The Dollar exchange rate to Naira is {0}/$  as of {1}",Deserializenw.rates["NGN"],formatDate);
                  
                }catch(Exception ex){
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
