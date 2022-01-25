using System.Collections.Generic;

namespace FoodOrder.Application.Garnishes.Queries.GetGarnishList
{
	public class GarnishListVm
	{
		public IList<GarnishLookupDto> Garnishes { get; set; }
	}
}