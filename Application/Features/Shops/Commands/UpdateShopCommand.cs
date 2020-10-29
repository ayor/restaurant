using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Commands
{
    public class UpdateShopCommand : IRequest<Shop>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string LocalGovernmentArea { get; set; }
        public string Address { get; set; }
    }
}