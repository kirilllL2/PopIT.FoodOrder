using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Soups.Commands.UpdateSoup;

namespace FoodOrder.WebApi.Models
{
	public class UpdateSoupDto : IMapWith<UpdateSoupCommand>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateSoupDto, UpdateSoupCommand>();
		}
	}
}
