using System.Collections.Generic;

namespace FoodOrder.Application.Beverages.Queries.GetBeverageList
{
	public class BeverageListVm
	{
		public IList<BeverageLookupDto> Beverages { get; set; }
	}
}