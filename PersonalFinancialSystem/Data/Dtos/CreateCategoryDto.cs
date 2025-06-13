using PersonalFinancialSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinancialSystem.Data.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public CategoryType Type { get; set; }
    }
}
