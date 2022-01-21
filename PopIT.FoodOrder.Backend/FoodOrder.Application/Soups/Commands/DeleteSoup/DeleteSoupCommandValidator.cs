using FluentValidation;
using System;

namespace FoodOrder.Application.Soups.Commands.DeleteSoup
{
	public class DeleteSoupCommandValidator : AbstractValidator<DeleteSoupCommand>
	{
		public DeleteSoupCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
