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

        public int AllActivedUsersNumber()
        {
            return this.GetMany(u => u.accountState == "ACTIVATED").Count();
        }

        public int AllBanndUsersNumber()
        {
            return this.GetMany(u => u.banState == 1).Count();
        }

        public int AllUnbannedUsersNumber()
        {
            return this.GetMany(u => u.banState == 0).Count();
        }

        public int AllUsersNumber()
        {
            return this.GetMany().Count();
        }

        public HashSet<String> GetAllCountries()
        {
            HashSet<String> countries=new HashSet<String>();
            var user = this.GetMany().ToList();
            foreach (User users in user )
            {
                countries.Add(users.country);
            }

            return countries;
        }
    }
}
