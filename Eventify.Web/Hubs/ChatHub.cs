using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eventify.Service;
using Microsoft.AspNet.SignalR;

namespace Eventify.Web.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.newMessage(message);
            MessageService messageService = new MessageService();
            Clients.All.getMessages(messageService.GetMany().ToList());


        }

    }
}