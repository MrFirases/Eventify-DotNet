using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventify.Service;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Eventify.Data.Models;

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

        public ActionResult Index()
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