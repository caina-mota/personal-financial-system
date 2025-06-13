using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinancialSystem.Models
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string? Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
