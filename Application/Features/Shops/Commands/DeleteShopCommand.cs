using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Commands
{
    public class DeleteShopCommand : IRequest<Shop>
    {
        public DeleteShopCommand(Shop shop)
        {
            Shop = shop;
        }

        public Shop Shop { get; }
    }
}