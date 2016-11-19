using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Infrastructure;
using Eventify.Data.Models;
using Service.Pattern;

namespace Eventify.Service
{
    public class EventService:MyServiceGeneric<Myevent>,IEventService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);
        //
        public EventService() : base(itw)
        {
        }

      
    }
}
