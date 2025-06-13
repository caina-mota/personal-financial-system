using AutoMapper;
using PersonalFinancialSystem.Data.Dtos;
using PersonalFinancialSystem.Models;

namespace PersonalFinancialSystem.Profiles
{
    public class ExpensesProfile : Profile
    {
        public ExpensesProfile() 
        {
            CreateMap<CreateExpenseDto, Expense>();
            CreateMap<Expense, ReadExpenseDto>()
                .ForMember(expenseDto => expenseDto.Category, option => option.MapFrom(expense => expense.Category));
        }
    }
}
