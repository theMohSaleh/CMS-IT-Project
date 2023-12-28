using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CMSWebpage.Model
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [StringLength(30)]
        public string CategoryName { get; set; } = null!;

        [InverseProperty("Category")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
