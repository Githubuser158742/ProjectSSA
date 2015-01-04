using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITBedrijf.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Login")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        public string Login { get; set; }

        [Required]
        [DisplayName("Wachtwoord")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Naam Database")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        public string DbName { get; set; }

        [Required]
        [DisplayName("Login Database")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        public string DbLogin { get; set; }

        [Required]
        [DisplayName("Database Wachtwoord")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 6)]
        public string DbPassword { get; set; }

        [Required]
        [DisplayName("Naam Vereniging")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        public string OrganisationName { get; set; }

        [Required]
        [DisplayName("Adres")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} karakters lang zijn.", MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Telefoon Nummer")]
        [Phone]
        public string Phone { get; set; }
    }
}