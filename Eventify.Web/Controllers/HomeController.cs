using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventify.Service;
using Microsoft.AspNet.Identity;
using Eventify.Data.Models;

namespace Eventify.Web.Controllers
{
    public class HomeController : Controller
    {
        IEventService eventService = null;
        IUserService userService = null;

        public HomeController()
        {
            eventService = new EventService();
            userService = new UserService();
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {

                User user = userService.GetById(int.Parse(User.Identity.GetUserId()));
                ViewBag.MyConntectedUser = user;

                return View();

            }
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