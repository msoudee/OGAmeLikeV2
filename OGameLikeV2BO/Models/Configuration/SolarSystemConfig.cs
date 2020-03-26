using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models.Configuration
{
    public class SolarSystemConfig
    {
        [DisplayName("Nombre de systèmes solaires :")]
        public int? SystemSolarNbr { get; set; }

        [DisplayName("Nombre de planètes par systèmes :")]
        public int? PlanetPerSolarSystem { get; set; }
    }
}
