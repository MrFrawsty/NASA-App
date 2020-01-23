using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class Apod
    {
        public string CopyRight { get; set; }

        public string Date { get; set; }

        public string Explanation { get; set; }

        public Uri HDUri { get; set; }

        public Uri Url { get; set; }

        public string Media_Type { get; set; }


    }
}
