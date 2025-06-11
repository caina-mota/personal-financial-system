using Microsoft.EntityFrameworkCore;
using PersonalFinancialSystem.Models;

namespace PersonalFinancialSystem.Data
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext(DbContextOptions<ExpensesContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Category)
                .WithOne()
                .HasForeignKey<Category>("ExpenseId");

            modelBuilder.Entity<Revenue>()
                .HasOne(r => r.Category)
                .WithOne()
                .HasForeignKey<Category>("RevenueId");
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
