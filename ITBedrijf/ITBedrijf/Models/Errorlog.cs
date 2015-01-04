using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ITBedrijf.Models
{
    public class Errorlog
    {
        public int RegisterID { get; set; }

        [DisplayName("Naam Kassa")]
        public string RegisterName { get; set; }

        [DisplayName("Naam Toestel")]
        public string Device { get; set; }

        [DisplayName("Datum")]
        public DateTime Timestamp { get; set; }

        [DisplayName("Fout Bericht")]
        public string Message { get; set; }

        [DisplayName("Stacktrace")]
        public string Stacktrace { get; set; }
    }
}