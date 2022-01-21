using System;
using MediatR;

namespace FoodOrder.Application.Soups.Queries.GetSoupDetails
{
    public class GetSoupDetailsQuery : IRequest<SoupDetailsVm>
    {
        public Guid Id { get; set; }
    }
}