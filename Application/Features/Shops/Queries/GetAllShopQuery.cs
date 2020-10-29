using System.Collections.Generic;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Queries
{
    public class GetAllShopQuery : IRequest<List<Shop>>
    {
    }
}