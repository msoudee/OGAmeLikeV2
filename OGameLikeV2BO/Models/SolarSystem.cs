using System;
using System.Collections.Generic;
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
	}
}
