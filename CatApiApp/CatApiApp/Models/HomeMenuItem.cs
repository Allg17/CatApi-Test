﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CatApiApp.Models
{
    public enum MenuItemType
    {
        Home,
        ListCats,
        FavoriteCats
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public ImageSource Icon { get; set; }
    }
}
