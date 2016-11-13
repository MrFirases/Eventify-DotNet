using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventify.Data.Models;
using Eventify.Service;

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

            IEnumerable<Reservation> queryable = ReservationService.
                GetMany(
                    reservation => reservation.reservationState == "CONFIRMED" && reservation.timerState == "FINISHED")
                .GroupBy(reservation => reservation.reservationDate.Value.Month)
                .Select(
                    grouping =>
                        new Reservation()
                        {
                            id = grouping.Key,
                            amount = grouping.Sum(reservation => reservation.amount)
                        });
            ViewBag.AmountByDate = queryable;



            IEnumerable<Reservation> reservationsbyState = ReservationService.GetMany(reservation => reservation.timerState=="FINISHED")
                .GroupBy(reservation => reservation.reservationState)
                .Select(
                    grouping =>
                        new Reservation()
                        {
                            reservationState = grouping.Key,
                            id = grouping.Count()
                        });
            ViewBag.ReservationByState = reservationsbyState;

            IEnumerable<Reservation> reservations = ReservationService
                .GetMany(
                    reservation => reservation.timerState == "FINISHED")
                .ToList();
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
    }
}
