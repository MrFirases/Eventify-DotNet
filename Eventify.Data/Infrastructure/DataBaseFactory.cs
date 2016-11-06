using Eventify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Data.Infrastructure
{

    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private eventifyContext context;

        public eventifyContext DBcontext { get { return context; } }

        public DataBaseFactory()
        {
            this.context = new eventifyContext();
        }

        protected override void DisposeCore()
        {
            if (DBcontext != null)
                DBcontext.Dispose();
        }
    }
}
