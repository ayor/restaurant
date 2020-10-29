using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Queries
{
    public class GetShopByIdQuery : IRequest<Shop>
    {
        public GetShopByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}