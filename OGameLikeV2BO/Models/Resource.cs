using System;

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

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int? LastQuantity
		{
			get { return lastQuantity; }
			set { lastQuantity = value; }
		}

		public DateTime LastUpdate
		{
			get { return lastUpdate; }
			set { lastUpdate = value; }
		}
	}
}