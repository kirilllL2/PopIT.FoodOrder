using FluentValidation;
using System;

namespace FoodOrder.Application.Meats.Commands.DeleteMeat
{
	public class DeleteMeatCommandValidator : AbstractValidator<DeleteMeatCommand>
	{
		public DeleteMeatCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
