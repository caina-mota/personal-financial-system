﻿using PersonalFinancialSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinancialSystem.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}