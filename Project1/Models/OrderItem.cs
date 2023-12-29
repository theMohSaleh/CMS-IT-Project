using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CMSWebpage.Model
{
    public partial class OrderItem
    {
        [Key]
        [Column("OrderItemID")]
        public int OrderItemId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("ItemID")]
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }

        [ForeignKey("ItemId")]
        [InverseProperty("OrderItems")]
        public virtual Item Item { get; set; } = null!;
        [ForeignKey("OrderId")]
        [InverseProperty("OrderItems")]
        public virtual Order Order { get; set; } = null!;
    }
}
