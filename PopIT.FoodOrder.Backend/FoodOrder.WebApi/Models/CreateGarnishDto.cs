using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Garnishes.Commands.CreateGarnish;

namespace FoodOrder.WebApi.Models
{
	public class CreateGarnishDto : IMapWith<CreateGarnishCommand>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateGarnishDto, CreateGarnishCommand>();
		}
	}
}
