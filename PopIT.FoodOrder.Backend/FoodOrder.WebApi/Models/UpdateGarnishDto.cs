using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Garnishes.Commands.UpdateGarnish;

namespace FoodOrder.WebApi.Models
{
	public class UpdateGarnishDto : IMapWith<UpdateGarnishCommand>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateGarnishDto, UpdateGarnishCommand>();
		}
	}
}
