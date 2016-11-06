using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Models;
using Service.Pattern;

namespace Eventify.Service
{
    public interface IEventService :IMyServiceGeneric<Myevent>
    {
    }
}
