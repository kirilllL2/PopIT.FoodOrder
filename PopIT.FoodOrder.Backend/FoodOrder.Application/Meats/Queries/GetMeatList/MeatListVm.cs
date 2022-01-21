using System.Collections.Generic;

namespace FoodOrder.Application.Meats.Queries.GetMeatList
{
    public class MeatListVm
    {
        public IList<MeatLookupDto> Meats { get; set; }
    }
}