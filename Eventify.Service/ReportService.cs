using Eventify.Data.Infrastructure;
using Eventify.Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Service
{
   public class ReportService : MyServiceGeneric<Report>, IReportService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public ReportService() : base(itw)
        {

        }
    }
}
