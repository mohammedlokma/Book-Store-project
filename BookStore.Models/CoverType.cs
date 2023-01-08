﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cover Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
