using System;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.Soups.Queries.GetSoupList
{
    public class SoupLookupDto : IMapFrom<Soup>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}