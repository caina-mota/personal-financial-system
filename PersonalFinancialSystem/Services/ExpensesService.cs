using AutoMapper;
using PersonalFinancialSystem.Data;
using PersonalFinancialSystem.Data.Dtos;
using PersonalFinancialSystem.Models;

namespace PersonalFinancialSystem.Services
{
    public class ExpensesService
    {
        private IMapper _mapper;
        private ExpensesContext _context;

        public ExpensesService(IMapper mapper, ExpensesContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Expense> CreateExpense(CreateExpenseDto dto, Guid UserId)
        {
            Expense expense = _mapper.Map<Expense>(dto);
            expense.Id = new Guid();
            expense.UserId = UserId;

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return expense;
        }

        public ReadExpenseDto FindById(Guid id)
        {
            Expense expense = _context.Expenses.FirstOrDefault(expense => expense.Id == id);

            if (expense == null)
                return null;
            
            return _mapper.Map<ReadExpenseDto>(expense);
        }
    }
}
