using MediatR;
using System;

namespace FoodOrder.Application.Garnishes.Queries.GetGarnishDetails
{
	public class GetGarnishDetailsQuery : IRequest<GarnishDetailsVm>
	{
		public Guid Id { get; set; }
	}
}
