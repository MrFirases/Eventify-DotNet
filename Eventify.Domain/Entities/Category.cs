using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            this.favorites = new List<Favorite>();
            this.myevents = new List<Myevent>();
        }

        public int id { get; set; }
        public string categoryName { get; set; }
        public virtual ICollection<Favorite> favorites { get; set; }
        public virtual ICollection<Myevent> myevents { get; set; }
    }
}
