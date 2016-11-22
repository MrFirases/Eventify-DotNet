using Eventify.Data.Models;
using Eventify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eventify.Web.Controllers
{
    public class OrganizationController : Controller
    {
        private IOrganizationService organizationService = null;
        private IUserService userService = null;
        private IEventService eventService = null;
       

        public OrganizationController()
        {
            organizationService = new OrganizationService();
            userService = new UserService();
            eventService = new EventService();
        }



        // GET: Organization
        public ActionResult Index()
        {
            var oranizations = organizationService.GetMany();
            ViewBag.User = userService.GetMany();

            
            
            return View(oranizations);
        }


        [HttpPost]
        public ActionResult Index(string searchString)
        {
            IEnumerable<Organization> organization;
            
            ViewBag.User = userService.GetMany();
            organization = organizationService.GetMany(o => o.creationDate.ToString().Contains(searchString) ||
            o.organizationName.Contains(searchString) || o.organizationType.Contains(searchString));
            return View(organization);
        }

        // GET: Organization/Details/5
        public ActionResult Details(int id)
        {
            Organization organization = organizationService.GetById(id);

            List<User> users = new List<User>();
            

            foreach (var item in organizationService.GetById(id).organizers)
            {
                users.Add(userService.GetById(item.idUser));
            }

            ViewBag.Users = users;

            ViewBag.User = userService.GetById((int)organization.user_id);
            ViewBag.Event = eventService.GetMany(e => e.organization_id == id);
            


            return View(organizationService.GetById(id));
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
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

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
            Organization organization = organizationService.GetById(id);
            return View(organization);
        }

        // POST: Organization/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                Organization organization = organizationService.GetById(id);



                string dateTime = Request.Form["creationDate"];
                DateTime dt = Convert.ToDateTime(dateTime);
                // Specify exactly how to interpret the string.  
                IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

    
                DateTime dt2 = DateTime.Parse(dateTime, culture, System.Globalization.DateTimeStyles.AssumeLocal);



                organization.creationDate = dt2;


                organization.organizationName = Request.Form["organizationName"];
                organization.organizationType = Request.Form["organizationType"];
               
                organizationService.Update(organization);
                organizationService.commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Organization/Delete/5
        public ActionResult Delete(int id)
        {

            Organization organization = organizationService.GetById(id);
            return View(organization);
        }   

        // POST: Organization/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Statistik ()
        {
            int NbMorale = organizationService.getNbMorale();
            int NbPhysique = organizationService.getNbPhysique();

            ViewBag.NbMorale = NbMorale;
            ViewBag.NbPhysique = NbPhysique;

            ViewBag.Months= organizationService.GetMonths();
            ViewBag.MonthNumbers = organizationService.GetMonthsNumber();
            return View();
        }
    }
}
