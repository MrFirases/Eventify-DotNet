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
    public class ReservationController : Controller
    {
        ReservationService ReservationService = new ReservationService();
        // GET: Reservation
        public ActionResult Index()
        {

            ViewBag.Total = ReservationService.getAllAmount();

            ViewBag.OurPart = ReservationService.getOurAmount();

            ViewBag.ConfirmedTransaction =
                ReservationService.GetMany(
                        reservation => reservation.reservationState == "CONFIRMED" && reservation.timerState == "FINISHED")
                    .Count();

            //Amount by Month
            IEnumerable<Reservation> AmountByMonth = ReservationService.AmountByMonth();
            ViewBag.AmountByMonth = AmountByMonth;


            //Amount by Year
            IEnumerable<Reservation> AmountByYear = ReservationService.AmountByYear();
            ViewBag.AmountByYear = AmountByYear;




            //Reservation By Reservation State
            IEnumerable<Reservation> reservationsbyState = ReservationService.reservationsbyState();
            ViewBag.ReservationByState = reservationsbyState;

            //All Reservation Finished
            IEnumerable<Reservation> reservations = ReservationService
                .GetMany(
                    reservation => reservation.timerState == "FINISHED")
                .ToList();


            //Reservation By Payment Method 
            IEnumerable<Reservation> reservationsByPaymentMethod = ReservationService.reservationsByPaymentMethod();
            ViewBag.ReservationByPayment = reservationsByPaymentMethod;



            //Reservation By Timer State 
            IEnumerable<Reservation> reservationsByTimerState = ReservationService.reservationsByTimerState();
            ViewBag.reservationsByTimerState = reservationsByTimerState;



            return View(reservations);
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
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

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
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

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
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

        public ActionResult StatisticsbyEventsAndTickets()
        {

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;


            //Reservation By Events
            IEnumerable<Reservation> reservationsByEvents = ReservationService.reservationsByEvents();
            ViewBag.reservationsByEvents = reservationsByEvents;



            //Reservation By Tickets In Events
            IEnumerable<Reservation> reservationsByTicketsEvents = ReservationService.reservationsByTicketsEvents();
            ViewBag.reservationsByTicketsEvents = reservationsByTicketsEvents;




            return View();
        }


    }
}
