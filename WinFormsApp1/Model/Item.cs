using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Model
{
    public partial class Item
    {
        public Item()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        [Column("ItemID")]
        public int ItemId { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Column("itemName")]
        [StringLength(50)]
        public string ItemName { get; set; } = null!;
        [Column("itemDescription")]
        [StringLength(100)]
        public string? ItemDescription { get; set; }
        public double Price { get; set; }
        [Column("ImageID")]
        public int ImageId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Items")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey("ImageId")]
        [InverseProperty("Items")]
        public virtual Images Image { get; set; } = null!;
        [InverseProperty("Item")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
