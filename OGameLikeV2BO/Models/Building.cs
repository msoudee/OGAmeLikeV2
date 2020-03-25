using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

		[StringLength(20, MinimumLength = 5)]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		[Range(1, Int32.MaxValue)]
		public int? Level
		{
			get { return level; }
			set { level = value; }
		}

		[NotMapped]
		public virtual int? cellNb
		{
			get { return 0;  }
		}

		[NotMapped]
		public virtual List<Resource> TotalCost
		{
			get { return null; }
		}

		[NotMapped]
		public virtual List<Resource> NextCost
		{
			get { return null;  }
		}

		public Building()
		{
			this.name = "";
			this.level = 1;
		}
	}
}
