using Eventify.Data.Models;
using Eventify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eventify.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService = null;
        

        public UserController()
        {
            userService = new UserService();
           
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

            user = userService.GetMany(u=>u.firstName.Contains(searchString));
            return View(user);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            
            IUserService userService = new UserService();
            User user = userService.GetById(id);
            userService.commit();

            return View(user);
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
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
    }
}
