using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Eventify.Data.Models
{
    public partial class Notification
    {
        public int id { get; set; }
        [JsonProperty(".notificationDate")]
        public Nullable<System.DateTime> notificationDate { get; set; }
        public string notificationDescription { get; set; }
        public string notificationTitle { get; set; }
        public int notificationStatus { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual User user { get; set; }
    }
}
