using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Features.Shops.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Handlers
{
    public class UpdateShopHandler : IRequestHandler<UpdateShopCommand, Shop>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;

        public UpdateShopHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<Shop> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            var isShop = await _shopRepository.GetByIdAsync(request.Id);
            if (isShop == null) throw new ApiException("Product Not Found.");
            var shop = _mapper.Map<Shop>(request);

            return await _shopRepository.UpdateAsync(shop);
        }
    }
}