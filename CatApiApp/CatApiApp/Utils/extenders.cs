using System;
using System.Collections.Generic;
using System.Text;

namespace CatApiApp.Utils
{
    public static class extenders
    {
        public static int Toint(this object str)
        {
            int.TryParse(str.ToString(), out int value);
            return value;
        }
    }
}
