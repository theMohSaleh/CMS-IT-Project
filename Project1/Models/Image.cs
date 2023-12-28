using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CMSWebpage.Models
{
    public partial class Image
    {
        public Image()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("ImageID")]
        public int ImageId { get; set; }
        [StringLength(255)]
        public string Title { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;

        [InverseProperty("Image")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
