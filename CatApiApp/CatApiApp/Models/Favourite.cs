using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatApiApp.Models
{
    public class Favourite
    {
        public string image_id { get; set; }
        public string sub_id { get; set; }
    }

    public class Response
    {
        public string id { get; set; }
        public string message { get; set; }
    }
}
