using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models
{
    public class SolarSystem : IDbEntity
    {
		private long? id;
		private string name;
		private List<Planet> planets;

		public long? Id
		{
			get { return id; }
			set { id = value; }
		}

		[StringLength(20, MinimumLength = 5)]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public List<Planet> Planets
		{
			get { return planets; }
			set { planets = value; }
		}

		public SolarSystem()
		{
			this.name = "";
			this.planets = new List<Planet>();
		}
	}
}
