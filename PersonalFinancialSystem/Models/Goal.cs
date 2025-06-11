using PersonalFinancialSystem.Enums;

namespace PersonalFinancialSystem.Models
{
    public class Goal
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Description { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public GoalStatus Status { get; set; }  // Enum: Pending, Achieved, Failed

        //public GoalStrategyType StrategyType { get; set; } // Enum para Strategy Pattern
    }
}
