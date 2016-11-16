using Eventify.Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Service
{
    public interface IUserService : IMyServiceGeneric<User>
    {
        int AllUsersNumber();
        int AllActivedUsersNumber();
        int AllBanndUsersNumber();
        int AllUnbannedUsersNumber();

        HashSet<String> GetAllCountries();
        
    }
}
