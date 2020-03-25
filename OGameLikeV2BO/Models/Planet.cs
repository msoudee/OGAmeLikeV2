using OGameLikeV2BO.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models
{
    public class Planet : IDbEntity
    {
		private long? id;
		private string name;
		private int? caseNb;
		private List<Resource> resources;

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

		[Range(1, Int32.MaxValue)]
		public int? CaseNb
		{
			get { return caseNb; }
			set { caseNb = value; }
		}

		[PlanetResourceValidator]
		public virtual List<Resource> Resources
		{
			get { return resources; }
			set { resources = value; }
		}

		public Planet()
		{
			this.name = "";
			this.caseNb = 0;
			this.resources = new List<Resource>();
		}
	}
}
