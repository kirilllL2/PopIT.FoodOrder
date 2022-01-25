using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Soups.Queries.GetSoupDetails
{
    public class GetSoupDetailsQueryHandler : IRequestHandler<GetSoupDetailsQuery, SoupDetailsVm>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSoupDetailsQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) => 
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<SoupDetailsVm> Handle(GetSoupDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Soups
                .FirstOrDefaultAsync(soup => soup.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityIdNotFoundException(nameof(Soup), request.Id);
            }

            return _mapper.Map<SoupDetailsVm>(entity);
        }
    }
}