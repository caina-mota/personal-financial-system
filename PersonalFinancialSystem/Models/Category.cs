﻿using PersonalFinancialSystem.Enums;

namespace PersonalFinancialSystem.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}