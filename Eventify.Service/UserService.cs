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

        
        public Dictionary<string, int> GetPieChartStat()
        {
            Dictionary<String, Int32> data = new Dictionary<String, Int32>();

            foreach (var line in this.GetMany().GroupBy(info => info.country)
                       .Select(group => new {
                           country = group.Key,
                           Count = group.Count()
                       })
                       .OrderBy(x => x.country))

            {
                data.Add(line.country, line.Count);


            }

            return data;


        }

        public Dictionary<string, int> GetUsersByDateChart()
        {

            Dictionary<String, Int32> data = new Dictionary<String, Int32>();

            foreach (var line in this.GetMany().GroupBy(info => info.creationDate.Value.ToString("yyyy"))
                       .Select(group => new {
                           year = group.Key,
                           Count = group.Count()
                       })
                       .OrderBy(x => x.year))

            {
                data.Add(line.year, line.Count);
                System.Diagnostics.Debug.WriteLine("{0} {1}", line.year, line.Count);

            }

            return data;



        }
    }
}
