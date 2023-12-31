﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CMSWebpage.Model
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        [StringLength(50)]
        public string? Office { get; set; }
        [StringLength(50)]
        public string? Number { get; set; }
        [StringLength(10)]
        public string Role { get; set; } = null!;

        [InverseProperty("User")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
