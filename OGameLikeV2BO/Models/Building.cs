using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models
{
    public abstract class Building : IDbEntity
    {
		private long? id;
		private string name;
		private int? level;

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

		public int? Level
		{
			get { return level; }
			set { level = value; }
		}

		public virtual int? cellNb()
		{
			return 0;
		}

		public virtual List<Resource> TotalCost()
		{
			return null;
		}

		public virtual List<Resource> nextCost()
		{
			return null;
		}
	}
}
