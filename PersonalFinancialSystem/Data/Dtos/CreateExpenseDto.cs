using PersonalFinancialSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinancialSystem.Data.Dtos
{
    public class CreateExpenseDto
    {
        public string Title { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Guid CategoryId { get; set; }
    }
}
