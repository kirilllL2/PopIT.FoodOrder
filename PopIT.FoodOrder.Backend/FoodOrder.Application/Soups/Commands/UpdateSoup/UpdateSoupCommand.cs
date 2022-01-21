using System;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Soups.Commands.UpdateSoup
{
    public class UpdateSoupCommand : IRequest, IMapTo<Meat>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}