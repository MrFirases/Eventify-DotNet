using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Eventify.Data.Models;
using Eventify.Service;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Eventify.Web.Hubs
{
    public class ChatHub : Hub
    {
        private string msg;
        [HubMethodName("send")]
        public void Send(string message,int userId)
        {
            MessageService messageService = new MessageService();
            Message msg = new Message()
            {
                message1 = message,
                claim = true,
                sended = false,
                user_id = userId,
                date = DateTime.Now
            };
            messageService.Add(msg);
            messageService.commit();
            Clients.All.newMessage(message);

        }


        [HubMethodName("getmessages")]
        public System.Threading.Tasks.Task<object> getMessages(int idUser)
        {
            MessageService messageService = new MessageService();
           List<Message> messages = messageService.GetMany(message =>message.user_id== idUser).Select(message => new Message()
           {
               message1 = message.message1 ,
               user_id = message.user_id,
               sended = message.sended
           }).ToList();
            
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            //var jsonSerialiser = new JavaScriptSerializer();
            //var json = jsonSerialiser.Serialize(messages);
            return context.Clients.All.displayMessages(messages);


        }


    }
}