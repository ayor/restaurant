using System.Threading;
using System.Threading.Tasks;
using Application.Features.Shops.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Handlers
{
    public class DeleteShopHandler : IRequestHandler<DeleteShopCommand, Shop>
    {
        private readonly IShopRepository _shopRepository;

        public DeleteShopHandler(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<Shop> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            return await _shopRepository.DeleteAsync(request.Shop);
        }
    }
}