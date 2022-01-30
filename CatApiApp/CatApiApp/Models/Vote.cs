using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CatApiApp.Models
{
    public class Vote
    {
        public string country_code { get; set; }
        public DateTime created_at { get; set; }
        public string id { get; set; }
        public string image_id { get; set; }
        public string sub_id { get; set; }
        public string Url { get; set; }
        public int value { get; set; }
    }
}
