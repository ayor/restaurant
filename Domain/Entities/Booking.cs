using Domain.Common;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public int UserId { get; set; }
        public int ShopId { get; set; }
    }
}