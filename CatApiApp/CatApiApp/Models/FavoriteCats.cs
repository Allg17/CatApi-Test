using System;
using System.Collections.Generic;
using System.Text;

namespace CatApiApp.Models
{
   public  class FavoriteCats
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public Image image { get; set; }
    }
}
