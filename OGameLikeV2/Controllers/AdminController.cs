using OGameLikeV2.Data;
using OGameLikeV2.Models;
using OGameLikeV2BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OGameLikeV2BO.Models.Configuration;
using System.Data.Entity;

namespace OGameLikeV2.Controllers
{
    public class AdminController : Controller
    {
        Context db = new Context();

        private string SOLAR_SYSTEM_CONF = "1";
        private string PLANET_CONF = "2";

        public ActionResult Configure()
        {
            var jsonConfSystem = db.Configuration.Find(SOLAR_SYSTEM_CONF);
            var jsonConfPlanet = db.Configuration.Find(PLANET_CONF);

            SolarSystemConfig solarSystemConfig = new SolarSystemConfig();
            PlanetConfig planetConfig = new PlanetConfig();

            if(jsonConfSystem != null && jsonConfPlanet != null)
            {
                solarSystemConfig = JsonConvert.DeserializeObject<SolarSystemConfig>(jsonConfSystem.Data);
                planetConfig = JsonConvert.DeserializeObject<PlanetConfig>(jsonConfPlanet.Data);
            } 
            else
            {
                jsonConfSystem = new ConfigJSON()
                {
                    Key = SOLAR_SYSTEM_CONF,
                    Data = JsonConvert.SerializeObject(solarSystemConfig)
                };

                jsonConfPlanet = new ConfigJSON()
                {
                    Key = PLANET_CONF,
                    Data = JsonConvert.SerializeObject(planetConfig)
                };

                db.Configuration.Add(jsonConfSystem);
                db.Configuration.Add(jsonConfPlanet);

                db.SaveChanges();
            }

            List<SelectListItem> res = new List<SelectListItem>();
            res.Add(new SelectListItem { Value = ResourceType.ENERGY.ToString(), Text = "Energie" });
            res.Add(new SelectListItem { Value = ResourceType.OXYGEN.ToString(), Text = "Oxygène" });
            res.Add(new SelectListItem { Value = ResourceType.STEEL.ToString(), Text = "Acier" });
            res.Add(new SelectListItem { Value = ResourceType.URANIUM.ToString(), Text = "Uranium" });

            List<SelectListItem> builds = new List<SelectListItem>();
            builds.Add(new SelectListItem { Value = ResourceType.ENERGY.ToString(), Text = "Centrale à énergie" });
            builds.Add(new SelectListItem { Value = ResourceType.OXYGEN.ToString(), Text = "Générateur d'oxygène" });
            builds.Add(new SelectListItem { Value = ResourceType.STEEL.ToString(), Text = "Générateur d'acier" });
            builds.Add(new SelectListItem { Value = ResourceType.URANIUM.ToString(), Text = "Générateur d'uranium" });

            ConfigurationViewModel cvm = new ConfigurationViewModel { SolarSystemConfig = solarSystemConfig, PlanetConfig = planetConfig, Buildings = builds, Resources = res};

            return View(cvm);
        }

        [HttpPost]
        public ActionResult Configure(ConfigurationViewModel cvm)
        {
            if(ModelState.IsValid)
            {
                ConfigJSON jsonConfSystem = new ConfigJSON()
                {
                    Key = SOLAR_SYSTEM_CONF,
                    Data = JsonConvert.SerializeObject(cvm.SolarSystemConfig)
                };
                ConfigJSON jsonConfPlanet = new ConfigJSON()
                {
                    Key = PLANET_CONF,
                    Data = JsonConvert.SerializeObject(cvm.PlanetConfig)
                };

                db.Configuration.Attach(jsonConfSystem);
                db.Configuration.Attach(jsonConfPlanet);

                db.Entry(jsonConfSystem).State = EntityState.Modified;
                db.Entry(jsonConfPlanet).State = EntityState.Modified;

                db.SaveChanges();

                return Redirect("/Home"); ;
            }

            List<SelectListItem> res = new List<SelectListItem>();
            res.Add(new SelectListItem { Value = ResourceType.ENERGY.ToString(), Text = "Energie" });
            res.Add(new SelectListItem { Value = ResourceType.OXYGEN.ToString(), Text = "Oxygène" });
            res.Add(new SelectListItem { Value = ResourceType.STEEL.ToString(), Text = "Acier" });
            res.Add(new SelectListItem { Value = ResourceType.URANIUM.ToString(), Text = "Uranium" });

            List<SelectListItem> builds = new List<SelectListItem>();
            builds.Add(new SelectListItem { Value = ResourceType.ENERGY.ToString(), Text = "Centrale à énergie" });
            builds.Add(new SelectListItem { Value = ResourceType.OXYGEN.ToString(), Text = "Générateur d'oxygène" });
            builds.Add(new SelectListItem { Value = ResourceType.STEEL.ToString(), Text = "Générateur d'acier" });
            builds.Add(new SelectListItem { Value = ResourceType.URANIUM.ToString(), Text = "Générateur d'uranium" });

            cvm.Resources = res;
            cvm.Buildings = builds;

            return View(cvm);
        }
    }
}