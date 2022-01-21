using FluentValidation;
using System;

namespace FoodOrder.Application.Garnishes.Commands.DeleteGarnish
{
	public class DeleteGarnishCommandValidator : AbstractValidator<DeleteGarnishCommand>
	{
		public DeleteGarnishCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
