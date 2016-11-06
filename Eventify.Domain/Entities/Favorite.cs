using System;
using System.Collections.Generic;

namespace Eventify.Data.Models
{
    public partial class Favorite
    {
        public int categoryId { get; set; }
        public int userId { get; set; }
        public int priority { get; set; }
        public virtual Category category { get; set; }
        public virtual User user { get; set; }
    }
}
