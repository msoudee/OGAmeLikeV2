using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLikeV2BO.Models
{
    [NotMapped]
	public class FunctionBuilding : Building
    {
		private List<Action> actions;

		public virtual List<Action> Actions
		{
			get { return actions; }
			set { actions = value; }
		}

		public FunctionBuilding()
		{
			this.actions = new List<Action>();
		}
	}
}
