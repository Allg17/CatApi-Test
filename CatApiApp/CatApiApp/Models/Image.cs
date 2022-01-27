using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CatApiApp.Models
{
    public class Image
    {
        public int height { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }


   

}
