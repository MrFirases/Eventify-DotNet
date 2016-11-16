using Eventify.Data.Models;
using Eventify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace Eventify.Web.Controllers
{
    public class ReportController : Controller
    {
        private IReportService reportService = null;
        private UserService UserService = null;
     //   private EventService EventService = new EventService();

        public ReportController()
        {
            reportService = new ReportService();
            UserService = new UserService();
        }
        // GET: Report
        public ActionResult Index(int? pageNumber)
        {
             
            var reports = reportService.GetMany().ToList().ToPagedList(pageNumber ?? 1, 3); 
            return View(reports);
            
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
           int? x = reportService.GetById(id).userWhoReport_id;
            ViewBag.User = UserService.GetById((int)x);
            var report = reportService.GetById(id);
            reportService.commit();

            return View(report);
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
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
        [HttpGet]
        
        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            Report report = reportService.GetById(id);
            return View(report);
        }

        // POST: Report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            if (ModelState.IsValid)
            {
                Report report = reportService.GetById(id);
                report.content = Request.Form["content"];
                report.reportDate = DateTime.Parse(Request.Form["reportDate"]);
                report.state = Int32.Parse(Request.Form["state"]);
                report.subject = Request.Form["subject"];

                reportService.Update(report);
                reportService.commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            Report report = reportService.GetById(id);
            reportService.Delete(report);
            reportService.commit();
            return RedirectToAction("Index");
        }

        // POST: Report/Delete/5
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








        //search function
        [HttpPost]
        public ActionResult Index(string searchString, int? pageNumber)
        {
            IEnumerable<Report> report;

            report = reportService.GetMany(u => u.subject.Contains(searchString) || u.content.Contains(searchString) ).ToList().ToPagedList(pageNumber ?? 1, 3); ;
            return View(report);
        }



    }
}
