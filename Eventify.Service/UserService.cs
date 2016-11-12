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
    public class UserService : MyServiceGeneric<User>, IUserService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);


        public UserService() : base(itw)
        {
        }
    }
}
