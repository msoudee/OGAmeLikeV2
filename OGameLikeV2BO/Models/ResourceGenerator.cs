using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models
{
    public class ResourceGenerator
    {
		private List<Resource> resourceBySecond;
		public virtual List<Resource> ResourceBySecond
		{
			get { return resourceBySecond; }
		}

		public ResourceGenerator()
		{
			this.resourceBySecond = new List<Resource>();
		}
	}
}
