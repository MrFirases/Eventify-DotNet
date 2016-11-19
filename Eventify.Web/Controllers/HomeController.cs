using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventify.Data.Models;
using Eventify.Service;
using Microsoft.Ajax.Utilities;

namespace Eventify.Web.Controllers
{
    public class HomeController : Controller
    {
         IEventService eventService = null;
        private IMessageService messageService = null;

        public HomeController()
        {
            eventService = new EventService();
            messageService = new MessageService();
        }
        public ActionResult Index()
        {
            IEnumerable<Message> messages =
                messageService.GetMany(message => message.sended == true && message.claim == true).DistinctBy(message => message.user_id).ToList();

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