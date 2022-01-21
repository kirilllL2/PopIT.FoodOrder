using System;

namespace FoodOrder.Application.Soups.Queries.GetSoupDetails
{
    public class SoupDetailsVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}