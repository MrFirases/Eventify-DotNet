using Eventify.Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Infrastructure;

namespace Eventify.Service
{
    public class OrganizationService : MyServiceGeneric<Organization>, IOrganizationService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public OrganizationService() : base(itw)
        {

        }
    }
}
