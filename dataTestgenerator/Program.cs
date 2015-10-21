using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataTestgenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            string qry = string.Empty;
            
            int iter = 100000;

            for (int i = 0; i < iter; i++)
			{
                DateTime date = start.AddDays(rnd.Next(range));
                short hourAdd = (short)rnd.Next(1, 24);

                short inUbication = (short)(rnd.Next() % 2 == 0 ? 1 : 2);
                DateTime inDatetime = date.AddHours(hourAdd);

                short payModule = (short)(rnd.Next() % 2 == 0 ? 5 : 6);
                DateTime payDatetime = inDatetime.AddHours(rnd.Next(5));

                short payType = (short)(rnd.Next() % 2 == 0 ? 1 : 2);
                Decimal amount = (Decimal)(rnd.NextDouble() * 100);

                short outUbication = (short)(rnd.Next() % 2 == 0 ? 3 : 4);
                DateTime outDatetime = payDatetime.AddMinutes(rnd.Next(15));

                qry = string.Format("insert into maFlow (inUbication, inDatetime, payModule, payDatetime, payType, amount, outUbication, outDatetime) values ({0},'{1}',{2},'{3}',{4},{5},{6},'{7}');", inUbication, inDatetime.ToString("s"), payModule, payDatetime.ToString("s"), payType, amount, outUbication, outDatetime.ToString("s"));

                var client = new RestClient(string.Format("{0}/{1}",dataTestgenerator.Properties.Settings.Default.apiDashboardUrl,dataTestgenerator.Properties.Settings.Default.apiVersion));

                var request = new RestRequest(string.Format("insert?query={0}",qry), Method.GET);
                request.AddHeader("Accept", "application/json");

                RestResponse response = client.Execute(request) as RestResponse;
                Console.WriteLine(response.Content);
			}
            Console.WriteLine("Proceso terminado");
            Console.ReadKey();
        }
    }
}
