using System.Collections.Generic;

namespace FoodOrder.Application.Soups.Queries.GetSoupList
{
    public class SoupListVm
    {
        public IList<SoupLookupDto> Soups { get; set; }
    }
}