using OGameLikeV2BO.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace OGameLikeV2BO.Models
{
    public class Resource : IDbEntity
    {
		private long? id;
		private string name;
		private int? lastQuantity;
		private DateTime lastUpdate;

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
		public int? LastQuantity
		{
			get { return lastQuantity; }
			set { lastQuantity = value; }
		}

		[DateTimeValidator]
		public DateTime LastUpdate
		{
			get { return lastUpdate; }
			set { lastUpdate = value; }
		}

		public Resource()
		{
			this.name = "";
			this.lastQuantity = 0;
			this.lastUpdate = DateTime.Now;
		}
	}
}