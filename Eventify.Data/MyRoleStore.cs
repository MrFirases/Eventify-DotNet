using Eventify.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eventify.Data
{
    public class MyRoleStore : RoleStore<MyRole, int, MyUserRole>
    {

        public MyRoleStore(eventifyContext context):base(context)
        {

        }
    }
}
