using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NetIdentity.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Precision(18, 2)]
        public decimal Total { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
