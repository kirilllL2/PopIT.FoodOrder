using FluentValidation;
using System;

namespace FoodOrder.Application.Garnishes.Queries.GetGarnishDetails
{
	public class GetGarnishDetailsQueryValidator : AbstractValidator<GetGarnishDetailsQuery>
	{
		public GetGarnishDetailsQueryValidator()
		{
			RuleFor(q => q.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
