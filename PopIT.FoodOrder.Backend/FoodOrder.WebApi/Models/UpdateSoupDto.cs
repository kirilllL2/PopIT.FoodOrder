using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Soups.Commands.UpdateSoup;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.WebApi.Models
{
	public class UpdateSoupDto : IMapWith<UpdateSoupCommand>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateSoupDto, UpdateSoupCommand>();
		}
	}
}
