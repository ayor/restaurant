using Domain.Common;

namespace Domain.Entities
{
    public class Booking : AuditableEntity
    {
        public string BookingId { get; set; }
        public string UserId { get; set; }
        public string ShopId { get; set; }
    }
}