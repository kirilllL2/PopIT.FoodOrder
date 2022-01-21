using System;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Meats.Commands.UpdateMeat;

namespace FoodOrder.WebApi.Models
{
    public class UpdateMeatDto : IMapTo<UpdateMeatCommand>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}