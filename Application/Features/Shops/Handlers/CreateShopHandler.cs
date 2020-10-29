using System.Threading;
using System.Threading.Tasks;
using Application.Features.Shops.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Handlers
{
    public class CreateShopHandler : IRequestHandler<CreateShopCommand, Shop>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;

        public CreateShopHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<Shop> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var vendor = _mapper.Map<Shop>(request);
            await _shopRepository.CreateAsync(vendor);
            return vendor;
        }
    }
}