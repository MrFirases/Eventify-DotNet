using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Data.Models
{
    public partial class Report
    {
        public int id { get; set; }
        public string content { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> reportDate { get; set; }
        public int state { get; set; }
        public string subject { get; set; }
        public Nullable<int> event_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> userWhoReport_id { get; set; }
        public virtual Myevent myevent { get; set; }
        public virtual User user { get; set; }
        public virtual User user1 { get; set; }
    }
}
