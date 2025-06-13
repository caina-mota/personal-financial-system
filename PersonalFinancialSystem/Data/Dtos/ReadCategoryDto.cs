using PersonalFinancialSystem.Enums;

namespace PersonalFinancialSystem.Data.Dtos
{
    public class ReadCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
