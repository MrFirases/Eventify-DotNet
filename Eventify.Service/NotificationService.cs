using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Infrastructure;
using Eventify.Data.Models;
using Service.Pattern;

namespace Eventify.Service
{
    public class NotificationService : MyServiceGeneric<Notification>, INotificationService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public NotificationService() : base(itw)
        {

        }

        public async Task<Notification> GetALLNotificationWithRest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Eventify-web/rest/events");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/products/1");
                if (response.IsSuccessStatusCode)
                {
                    Myevent myevent = await response.Content.ReadAsAsync<Myevent>();
                    Console.WriteLine("{0}\t${1}\t{2}", myevent.title, myevent.theme, myevent.eventType);
                }
            }

            return null;

        }

    }
}
