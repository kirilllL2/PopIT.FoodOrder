using MediatR;
using System;

namespace FoodOrder.Application.Beverages.Queries.GetBeverageDetails
{
	public class GetBeverageDetailsQuery : IRequest<BeverageDetailsVm>
	{
		public Guid Id { get; set; }
	}
}
