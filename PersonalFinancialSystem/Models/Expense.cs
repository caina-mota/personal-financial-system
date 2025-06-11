namespace PersonalFinancialSystem.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Category Category { get; set; }
    }
}
