using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        [HttpGet]
        public ActionResult RespondingWithMail(string email)
        {
            Session["emailTo"] = email;
            return View();
        }

        //Sending Email
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> RespondingMail(string contenu)
        {
            var body = "<p>Email From: {0} </p><p>Message:</p><p>{1}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(Session["emailTo"].ToString()));  // replace with valid value 
            message.From = new MailAddress("tft.codexit@gmail.com");  // replace with valid value
            message.Subject = "Respond Eventify";
            message.Body = string.Format(body, "tft.codexit@gmail.com", contenu);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "tft.codexit@gmail.com",  // replace with valid value
                    Password = "Codexit123"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Index");
            }
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
            {
                Message message1 = new Message();
                message1 = MessageService.GetById(id);
                message1.message1 = message.message1;
                message1.date = DateTime.Now;
                MessageService.Update(message1);
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


        public ActionResult Chat(int id)
        {
            ViewBag.idUser = id;
            return View();
        }
    }
}
