using FluentValidation;
using System;

namespace FoodOrder.Application.Soups.Queries.GetSoupDetails
{
	public class GetSoupDetailsQueryValidator : AbstractValidator<GetSoupDetailsQuery>
	{
		public GetSoupDetailsQueryValidator()
		{
			RuleFor(q => q.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
