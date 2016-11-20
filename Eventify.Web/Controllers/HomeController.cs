using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventify.Service;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Eventify.Data.Models;
using Newtonsoft.Json;

namespace Eventify.Web.Controllers
{
    public class HomeController : Controller
    {
         IEventService eventService = null;
        private IMessageService messageService = null;
        IUserService userService = null;

        public HomeController()
        {
            messageService = new MessageService();
            userService = new UserService();
        }

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Message> messages =
                messageService.GetMany(message => message.sended == true && message.claim == true).DistinctBy(message => message.user_id).ToList();



            if (Request.IsAuthenticated)
            {

                User user = userService.GetById(int.Parse(User.Identity.GetUserId()));
                ViewBag.MyConntectedUser = user;


                Session["MessageReceived"] = messages;
                Session["NbNewMessage"] = messages.Count();

                return View();

            }



            //Consuming Notification From JEE
            string url = "http://localhost:18080/Eventify-web/rest/notifications/1";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonMessage;
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }

                    IEnumerable<Notification> tokenResponse = (IEnumerable<Notification>)JsonConvert.DeserializeObject(jsonMessage, typeof(IEnumerable<Notification>));

                    Session["MyNotifications"] = tokenResponse;
                    Session["MyNotificationsNB"] = tokenResponse.Count();
                }
            }


            Session["MessageReceived"] = messages;
            Session["NbNewMessage"] = messages.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}