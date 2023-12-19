using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Model
{
    public partial class Images
    {
        public Images()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("ImageID")]
        public int ImageId { get; set; }
        [StringLength(255)]
        public string Title { get; set; } = null!;
        [StringLength(2000)]
        public byte[] ImageData { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
