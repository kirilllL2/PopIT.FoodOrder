using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Meats.Commands.CreateMeat;

namespace FoodOrder.WebApi.Models
{
    public class CreateMeatDto : IMapTo<CreateMeatCommand>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}