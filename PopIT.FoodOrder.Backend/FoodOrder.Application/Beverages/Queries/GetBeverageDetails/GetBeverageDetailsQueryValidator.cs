using FluentValidation;
using System;

namespace FoodOrder.Application.Beverages.Queries.GetBeverageDetails
{
	public class GetBeverageDetailsQueryValidator : AbstractValidator<GetBeverageDetailsQuery>
	{
		public GetBeverageDetailsQueryValidator()
		{
			RuleFor(q => q.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
