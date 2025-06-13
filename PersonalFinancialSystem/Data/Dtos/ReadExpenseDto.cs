using PersonalFinancialSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinancialSystem.Data.Dtos
{
    public class ReadExpenseDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public ReadCategoryDto? Category { get; set; }
    }
}
