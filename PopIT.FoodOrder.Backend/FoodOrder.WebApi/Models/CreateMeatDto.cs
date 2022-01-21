using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Meats.Commands.CreateMeat;

namespace FoodOrder.WebApi.Models
{
    public class CreateMeatDto : IMapWith<CreateMeatCommand>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateMeatDto, CreateMeatCommand>();
		}
	}
}