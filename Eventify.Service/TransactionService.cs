using Eventify.Data.Infrastructure;
using Eventify.Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Service
{
    public class TransactionService : MyServiceGeneric<Transaction>, ITransactionService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);

        public TransactionService() : base(itw)
        {

        }

    }
}
