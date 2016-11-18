using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eventify.Data.Models;
using Eventify.Service;
using Microsoft.Ajax.Utilities;

namespace Eventify.Web.Controllers
{
    public class MessageController : Controller
    {

        private IMessageService MessageService = new MessageService();
        private UserService UserService = new UserService();
       


        // GET: Message
        public ActionResult Index()
        {
            IEnumerable<Message> messages = 
                MessageService.GetMany(message => message.sended == true && message.claim == true).DistinctBy(message => message.user_id).ToList();
            return View(messages); 
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Message/Details/5
        public ActionResult MessageByUser(int id)
        {

            ViewBag.UserFullName = UserService.GetById(id).lastName + " " + UserService.GetById(id).firstName;

            IEnumerable<Message> messages =
            MessageService.GetMany(message => message.user_id == id);

            Session["CurrentMsgSender"] = id;
            return View(messages);
        }

         [HttpPost]
         public ActionResult MessageByUser(string msgResponse)
         {

             Message message = new Message();
             message.sended = false;
             message.user_id = (int?) Session["CurrentMsgSender"];
             message.claim = true;
            message.date= DateTime.Now;

             message.message1 = msgResponse;
            MessageService.Add(message);
            MessageService.commit();
            return RedirectToAction("Index");
        }







        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
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

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(MessageService.GetById(id));
        }

        // POST: Message/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Message message)
        {
            try
            {   Message message1 = new Message();
                message1 = MessageService.GetById(id);
                message1.message1 = Request.Form["message1"];

                message.date = DateTime.Now;
                MessageService.Update(message);
                MessageService.commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            MessageService.Delete(MessageService.GetById(id));
            MessageService.commit();
            return RedirectToAction("Index");
        }

        // POST: Message/Delete/5
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


        public static string GetPrettyDate(DateTime d)
        {
            // 1.
            // Get time span elapsed since the date.
            TimeSpan s = DateTime.Now.Subtract(d);

            // 2.
            // Get total number of days elapsed.
            int dayDiff = (int)s.TotalDays;

            // 3.
            // Get total number of seconds elapsed.
            int secDiff = (int)s.TotalSeconds;

            // 4.
            // Don't allow out of range values.
            if (dayDiff < 0 || dayDiff >= 31)
            {
                return null;
            }

            // 5.
            // Handle same-day times.
            if (dayDiff == 0)
            {
                // A.
                // Less than one minute ago.
                if (secDiff < 60)
                {
                    return "just now";
                }
                // B.
                // Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                // C.
                // Less than one hour ago.
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago",
                        Math.Floor((double)secDiff / 60));
                }
                // D.
                // Less than 2 hours ago.
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }
                // E.
                // Less than one day ago.
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            // 6.
            // Handle previous days.
            if (dayDiff == 1)
            {
                return "yesterday";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} days ago",
                dayDiff);
            }
            if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago",
                Math.Ceiling((double)dayDiff / 7));
            }
            return null;
        }



    }
}
