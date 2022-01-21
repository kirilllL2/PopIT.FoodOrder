using System.Collections.Generic;

namespace FoodOrder.Application.Orders.Queries.GetOrderList
{
    public class OrderListVm
    {
        public IList<OrderLookupDto> Orders { get; set; }
    }
}