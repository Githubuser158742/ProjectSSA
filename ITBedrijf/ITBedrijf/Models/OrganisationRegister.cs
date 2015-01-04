using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITBedrijf.Models
{
    public class OrganisationRegister
    {
        [Required]
        public int OrganisationID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        [DisplayName("Naam Vereniging")]
        public string OrganisationName { get; set; }

        [Required]
        [DisplayName("Login")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        public string Login { get; set; }

        [Required]
        public int RegisterID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        [DisplayName("Naam Kassa")]
        public string RegisterName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        [DisplayName("Naam Toestel")]
        public string Device { get; set; }

        [Required]
        [DisplayName("Van")]
        public DateTime FromDate { get; set; }

        [Required]
        [DisplayName("Tot")]
        public DateTime UntilDate { get; set; }
    }
}