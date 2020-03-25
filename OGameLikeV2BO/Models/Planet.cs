using System;
using System.Collections.Generic;
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

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int? CaseNb
		{
			get { return caseNb; }
			set { caseNb = value; }
		}

		public virtual List<Resource> Resources
		{
			get { return resources; }
			set { resources = value; }
		}

	}
}
