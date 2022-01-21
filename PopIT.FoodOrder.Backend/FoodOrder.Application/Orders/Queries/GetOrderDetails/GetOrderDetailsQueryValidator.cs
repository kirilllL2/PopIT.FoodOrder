using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Application.Orders.Queries.GetOrderDetails
{
	public class GetOrderDetailsQueryValidator : AbstractValidator<GetOrderDetailsQuery>
	{
		public GetOrderDetailsQueryValidator()
		{
			RuleFor(q => q.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");

			// TODO: Auth
			// RuleFor(q => q.UserId)
			//	.NotEqual(Guid.Empty).WithMessage("Идентификатор пользователя обязателен");
		}
	}
}
