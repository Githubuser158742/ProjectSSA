using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITBedrijf.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Naam Kassa")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        public string RegisterName { get; set; }

        [Required]
        [DisplayName("Naam Toestel")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        public string Device { get; set; }

        [Required]
        [DisplayName("Aankoop Datum")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [DisplayName("Verval Datum")]
        public DateTime ExpireDate { get; set; }
    }
}