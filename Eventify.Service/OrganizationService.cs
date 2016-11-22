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

        public IEnumerable<string> GetMonths()
        {
            List<String> months=new List<string>();

            foreach (var line in this.GetMany().GroupBy(info => info.creationDate.Value.ToString("MM"))
                       .Select(group => new {
                           month = group.Key,
                           Count = group.Count()
                       })
                       .OrderBy(x => x.month))

            {
                months.Add(line.month);
                System.Diagnostics.Debug.WriteLine("ch'har: "+ line.month);
            }

            return months;

        }



        public IEnumerable<int> GetMonthsNumber()
        {
            List<int> nbmonths = new List<int>();

            foreach (var line in this.GetMany().GroupBy(info => info.creationDate.Value.ToString("MM"))
                       .Select(group => new {
                           month = group.Key,
                           Count = group.Count()
                       })
                       .OrderBy(x => x.month))

            {
                nbmonths.Add(line.Count);
                System.Diagnostics.Debug.WriteLine("chif: "+ line.Count);

            }

            return nbmonths;
        }





        public int getNbMorale()
        {

            
            return GetMany(o => o.organizationType == "MORALE").Count();
        }

        public int getNbPhysique()
        {

            return GetMany(o => o.organizationType == "PHYSIQUE").Count();
        }






    /*
public List<int> CreationEventStat()
{
   IEnumerable<Organization> organizations;

   organizations = GetMany(o =>o.id != 0);
   foreach (var item in NbDates)
   {

   }


   }
   return  ;
}
*/

    }
}
