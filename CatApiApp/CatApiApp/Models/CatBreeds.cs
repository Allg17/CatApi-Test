using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CatApiApp.Models
{
    public class CatBreeds : NotificationObject
    {
        public int adaptability { get; set; }
        public int affection_level { get; set; }
        public string alt_names { get; set; }
        public string cfa_url { get; set; }
        public int child_friendly { get; set; }
        public string country_code { get; set; }
        public string country_codes { get; set; }
        public string description { get; set; }
        public int dog_friendly { get; set; }
        public int energy_level { get; set; }
        public int experimental { get; set; }
        public int grooming { get; set; }
        public int hairless { get; set; }
        public int health_issues { get; set; }
        public int hypoallergenic { get; set; }
        public string id { get; set; }
        public Image image { get; set; }
        public int indoor { get; set; }
        public int intelligence { get; set; }
        public int lap { get; set; }
        public string life_span { get; set; }
        public string name { get; set; }
        public int natural { get; set; }
        public string origin { get; set; }
        public int rare { get; set; }
        public string reference_image_id { get; set; }
        public int rex { get; set; }
        public int shedding_level { get; set; }
        public int short_legs { get; set; }
        public int social_needs { get; set; }
        public int stranger_friendly { get; set; }
        public int suppressed_tail { get; set; }
        public string temperament { get; set; }
        public string vcahospitals_url { get; set; }
        public string vetstreet_url { get; set; }
        public int vocalisation { get; set; }
        public Weight weight { get; set; }
        public string wikipedia_url { get; set; }
        public bool Favorite { get; set; }
        public bool IsThumbsEnable { get; set; }
        public string IDFavorite { get; set; }
        public ImageSource FavoriteImage { get; set; }

        public CatBreeds()
        {
            IsThumbsEnable = true;
        }
    }
}
