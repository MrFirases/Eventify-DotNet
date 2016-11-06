using Eventify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Data.Infrastructure
{
    public interface IDataBaseFactory
    {
        eventifyContext DBcontext { get; }
    }
}
