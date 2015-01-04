using ITBedrijf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITBedrijf.PresentationModels
{
    public class PMOrganisationRegister : OrganisationRegister
    {
        public MultiSelectList NewOrganisation { get; set; }
        public MultiSelectList NewRegister { get; set; }
    }
}