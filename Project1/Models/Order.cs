using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CMSWebpage.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        public int? TableNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public byte? IsOccupied { get; set; }
        [Column("isPaid")]
        public byte IsPaid { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Orders")]
        public virtual User? User { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
