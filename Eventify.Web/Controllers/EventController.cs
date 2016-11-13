using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventify.Service;

namespace Eventify.Web.Controllers
{
    //[Authorize]
    public class EventController : Controller
    {
        private IEventService eventService = null;

        public EventController()
        {
            eventService = new EventService();
        }
        // GET: Event
        public ActionResult Index()
        {
            var events = eventService.GetMany();
            return View(events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var myEvent = eventService.GetById(id);
            return View(myEvent);

        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
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

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            var myEvent = eventService.GetById(id);
            return View(myEvent);
        }

        // POST: Event/Edit/5
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

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
