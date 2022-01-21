using FluentValidation;
using System;

namespace FoodOrder.Application.Meats.Queries.GetMeatDetails
{
	public class GetMeatDetailsQueryValidator : AbstractValidator<GetMeatDetailsQuery>
	{
		public GetMeatDetailsQueryValidator()
		{
			RuleFor(q => q.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
