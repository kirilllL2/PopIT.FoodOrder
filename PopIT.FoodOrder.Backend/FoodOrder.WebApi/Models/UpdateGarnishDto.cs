using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Garnishes.Commands.UpdateGarnish;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.WebApi.Models
{
	public class UpdateGarnishDto : IMapWith<UpdateGarnishCommand>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateGarnishDto, UpdateGarnishCommand>();
		}
	}
}
