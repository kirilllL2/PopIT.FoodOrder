using AutoMapper;

namespace FoodOrder.Application.Common.Mappings
{
	public interface IMapWith<T>
	{
		void Mapping(Profile profile);
	}
}
