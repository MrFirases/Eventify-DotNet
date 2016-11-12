using Eventify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Pattern;

namespace Eventify.Service
{
    public interface IMessageService : IMyServiceGeneric<Message>
    {
        int countClaimNotResponded();
        int countClaim();
        IEnumerable<Message> getClaimsNotResponded();
    }
}
