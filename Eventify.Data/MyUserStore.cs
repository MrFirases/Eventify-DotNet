using Eventify.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Data
{
    public class MyUserStore : UserStore<User, MyRole, int, MyLogin, MyUserRole, MyClaim>, IUserPasswordStore<User, int>
    {
        public MyUserStore(eventifyContext context) : base(context)
        {
        }
    }
}
