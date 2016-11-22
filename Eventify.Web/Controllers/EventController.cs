﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Eventify.Data.Models;
using Eventify.Service;
using Eventify.Web.Models;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace Eventify.Web.Controllers
{
    //[Authorize]
    public class EventController : Controller
    {
        private IEventService eventService = null;
        private ICategoryService categoryService = null;
        private IOrganizationService organizationService = null;

        public EventController()
        {
            eventService = new EventService();
            categoryService = new CategoryService();
            organizationService = new OrganizationService();
        }

        // GET: Event
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            var events = eventService.GetMany().ToList();
            var categories = categoryService.GetMany();
            var totalVue = eventService.GetMany().Select(e=>e.nbViews).Sum();

            
            ViewBag.MyCategories = categories;
            ViewBag.totalVue = totalVue;

            return View(events);
        }
       

        public JsonResult ViewNbCount()
        {
            //logic here for getting your count
            var viewNbCount = eventService.GetMany().Select(e => e.nbViews).Sum();

            return Json(viewNbCount, JsonRequestBehavior.AllowGet);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var myEvent = eventService.GetById(id);
            ViewBag.MyImgs = myEvent.mymedias.Select(med => med.pathMedia);
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
            var categories = categoryService.GetMany().ToList();
            var organizations = organizationService.GetMany().ToList();

            ViewBag.MyCategories = categories;
            ViewBag.MyOrganizations = organizations;

            return View(myEvent);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var myEventToUpdate = eventService.GetById(id);
                /**/
                myEventToUpdate.createdAt = DateTime.Parse(collection["createdAt"]);
                myEventToUpdate.endTime = DateTime.Parse(collection["endTime"]);
                myEventToUpdate.eventState = collection["eventState"];
                myEventToUpdate.eventType = collection["eventType"];
                myEventToUpdate.facebookLink = collection["facebookLink"];
                myEventToUpdate.latitude = Int32.Parse(collection["latitude"]);
                myEventToUpdate.longitude = Int32.Parse(collection["longitude"]);
                myEventToUpdate.nbViews = Int32.Parse(collection["nbViews"]);
                myEventToUpdate.placeNumber = Int32.Parse(collection["placeNumber"]);
                myEventToUpdate.startTime = DateTime.Parse(collection["startTime"]);
                myEventToUpdate.theme = collection["theme"];
                myEventToUpdate.title = collection["title"];
                myEventToUpdate.twitterLink = collection["twitterLink"];
                myEventToUpdate.category_id = Int32.Parse(collection["category_id"]);
                myEventToUpdate.organization_id = Int32.Parse(collection["organization_id"]);

                /**/
                eventService.Update(myEventToUpdate);
                eventService.commit();

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


        public async System.Threading.Tasks.Task<ActionResult> ConsumeExternalAPI()
        {
            string url = "http://localhost:18080/Eventify-web/rest/events/1";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonMessage;
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }

                    Myevent tokenResponse = (Myevent) JsonConvert.DeserializeObject(jsonMessage, typeof(Myevent));

                    ViewBag.myevent = tokenResponse;
                }
            }
            return View();
        }
    }
}