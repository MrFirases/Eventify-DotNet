using Eventify.Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Service
{
   public interface IOrganizationService : IMyServiceGeneric<Organization>
    {
        int getNbPhysique();
        int getNbMorale();

        IEnumerable<String> GetMonths();
        IEnumerable<int> GetMonthsNumber();

    }
}
