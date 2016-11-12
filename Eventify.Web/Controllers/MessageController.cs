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
                MessageService.GetMany(message => message.sended == true && message.claim == true).DistinctBy(message => message.user_id);
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
            return View();
        }

        // POST: Message/Edit/5
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

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
    }
}
