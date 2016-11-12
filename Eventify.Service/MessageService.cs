using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Infrastructure;
using Eventify.Data.Models;
using Service.Pattern;

namespace Eventify.Service
{
    public class MessageService : MyServiceGeneric<Message>,IMessageService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public MessageService() : base(itw)
        {

        }


        public int countClaimNotResponded()
        {

            return dbfac.DBcontext.messages
                .Where(message => message.claim==true && message.sended==true).Count() -
                dbfac.DBcontext.messages
                .Where(message => message.claim == true && message.sended == false).Count();


        }

        public int countClaim()
        {
           return itw.getRepository<Message>().GetMany(message => message.claim == true && message.sended == true).Count();
        }

        public IEnumerable<Message> getClaimsNotResponded()
        {
            return itw.getRepository<Message>().GetMany(message => message.claim == true && message.sended == true)
                .Except(GetMany(message => message.claim == true && message.sended == false));
        }

    }
}
