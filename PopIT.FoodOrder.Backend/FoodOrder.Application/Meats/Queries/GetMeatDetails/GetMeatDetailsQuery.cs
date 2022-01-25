using System;
using MediatR;

namespace FoodOrder.Application.Meats.Queries.GetMeatDetails
{
    public class GetMeatDetailsQuery : IRequest<MeatDetailsVm>
    {
        public Guid Id { get; set; }
    }
}