using OGameLikeV2BO.Models.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OGameLikeV2.Models
{
    public class ConfigurationViewModel
    {
        public SolarSystemConfig SolarSystemConfig { get; set; }

        public PlanetConfig PlanetConfig { get; set; }

        public List<SelectListItem> Resources { get; set; }

        public List<SelectListItem> Buildings { get; set; }
    }
}