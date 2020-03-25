using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models
{
    public class ResourceGenerator
    {
		private List<Resource> resources;

		public virtual List<Resource> Resources
		{
			get { return resources; }
			set { resources = value; }
		}

		public ResourceGenerator()
		{
			this.resources = new List<Resource>();
		}
	}
}
