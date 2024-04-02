﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Item> Items { get; set; }
    }
}