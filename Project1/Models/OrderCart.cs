using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CMSWebpage.Model
{
    public partial class OrderCart
    {
        [Key]
        [Column("OrderCartID")]
        public int OrderCartID { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("ItemID")]
        public int ItemId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; } = null!;
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
    }
}
