using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models.Configuration
{
    public class PlanetConfig
    {
        [DisplayName("Type de ressource des planètes :")]
        public virtual List<string> ResourcesAvailable { get; set; }

        [DisplayName("Bâtiments disponibles par planètes :")]
        public virtual List<string> BuildingsAvailable { get; set; }
    }
}
