using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Meats.Queries.GetMeatDetails
{
    public class GetMeatDetailsQueryHandler : IRequestHandler<GetMeatDetailsQuery, MeatDetailsVm>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeatDetailsQueryHandler(IFoodOrderDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<MeatDetailsVm> Handle(GetMeatDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meats
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityIdNotFoundException(nameof(Meat), request.Id);
            }

            return _mapper.Map<MeatDetailsVm>(entity);
        }
    }
}