using Eventify.Data.Models;
using Eventify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace Eventify.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService userService = null;
        private IEventService eventService = null;
        private IReservationService reservationService = null;


        public UserController()
        {
            userService = new UserService();
            eventService = new EventService();
            reservationService = new ReservationService();
        }


        // GET: User
        public ActionResult Index()
        {
            

            IEnumerable<User> user;
            user = userService.GetMany();
            userService.commit();
            
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
           

            IEnumerable<User> user;

            user = userService.GetMany(u=>u.firstName.Contains(searchString) || u.lastName.Contains(searchString) || u.username.Contains(searchString));
            return View(user);
        }


        
        public ActionResult BannedUsers()
        {
           
            IEnumerable<User> user;

            user = userService.GetMany(u => u.banState==1);
            return View(user);
        }

        [HttpPost]
        public ActionResult BannedUsers(string searchString)
        {
           

            IEnumerable<User> user;

            //user = userService.GetMany(u => u.banState == 1);
            user = userService.GetMany(u => (u.firstName.Contains(searchString) || u.lastName.Contains(searchString) || u.username.Contains(searchString)) &&  u.banState == 1);
            return View(user);
        }



        public ActionResult UnBannedUsers()
        {

            IEnumerable<User> user;

            user = userService.GetMany(u => u.banState == 0);
            return View(user);
        }

        [HttpPost]
        public ActionResult UnBannedUsers(string searchString)
        {
           

            IEnumerable<User> user;

            //er = userService.GetMany(u => u.banState == 0);
            user = userService.GetMany(u => (u.firstName.Contains(searchString) || u.lastName.Contains(searchString) || u.username.Contains(searchString)) && u.banState == 0);
            return View(user);
        }



        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            


            User user = userService.GetById(id);

            
            ViewBag.MyEvents = eventService.GetMany(e => e.organization.user_id == id);
            ViewBag.ParticipatedEvents = userService.GetEventThatUserParticipateIn(id);

            return View(user);
        }

        
            public ActionResult Ban(int id)
        {
           

            User user = userService.GetById(id);
            user.banState = 1;
            userService.Update(user);
            userService.commit();

            var userlistToRedirect = userService.GetMany();
            return RedirectToAction("Index", "User");
           
        }

        public ActionResult UnBan(int id)
        {
           

            User user = userService.GetById(id);
            user.banState = 0;
            userService.Update(user);
            userService.commit();

            var userlistToRedirect = userService.GetMany();
            return RedirectToAction("Index", "User");

        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            

            User user = userService.GetById(id);

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                User user = userService.GetById(id);
                user.accountState = Request.Form["accountState"];
                user.email = Request.Form["email"];
                user.firstName = Request.Form["firstName"];
                user.lastName = Request.Form["lastName"];
                user.loyaltyPoint = Int32.Parse(Request.Form["loyaltyPoint"]);
                user.numTel = Request.Form["numTel"];
                user.username = Request.Form["username"];
                userService.Update(user);
                userService.commit();
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        public ActionResult Insights()
        {
           

            //PIE CHART INSIGHT
            Dictionary<String, Int32> data = userService.GetPieChartStat();
            ViewBag.Countries = data.Keys.ToList();
            ViewBag.NbCountries = data.Values.ToList();
            //PIE CHART INSIGHT

            //AMCHART
            Dictionary<String, Int32> data1 = userService.GetUsersByDateChart();
            ViewBag.Date = data1.Keys.ToList();
            ViewBag.NbUsers = data1.Values.ToList();
            //AMCHART

            ViewBag.Allusersnumber = userService.AllUsersNumber();
            ViewBag.AllBannednumber = userService.AllBanndUsersNumber();
            ViewBag.AllUnbannednumber = userService.AllUnbannedUsersNumber();
            ViewBag.AllActivednumber = userService.AllActivedUsersNumber();
            return View();
        }

        [HttpGet]
        public int GetNumberOfCountries(String country)
        {
            
            return userService.GetMany(u => u.country == "country").Count();
        }


    }
}
