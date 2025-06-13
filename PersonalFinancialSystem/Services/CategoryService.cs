using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalFinancialSystem.Data;
using PersonalFinancialSystem.Data.Dtos;
using PersonalFinancialSystem.Enums;
using PersonalFinancialSystem.Models;

namespace PersonalFinancialSystem.Services
{
    public class CategoryService
    {
        IMapper _mapper;
        ExpensesContext _context;

        public CategoryService(IMapper mapper, ExpensesContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        internal async Task<Category> CreateCategory(CreateCategoryDto dto)
        {
            if ((int)dto.Type > 1)
                throw new InvalidDataException($"Type: {dto.Type} not Allowed");

            Category category = _mapper.Map<Category>(dto);

            category.Id = new Guid();

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        internal ICollection<ReadCategoryDto> FindAll()
        {
            ICollection<Category> categories = _context.Categories.ToList();
            if (categories == null || categories.Count < 1) { return new List<ReadCategoryDto>(); }
            return _mapper.Map<ICollection<ReadCategoryDto>>(categories);
        }

        internal ReadCategoryDto FindById(Guid categoryId)
        {
             Category category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category == null) { return null; }
            
            return _mapper.Map<ReadCategoryDto>(category);
        }
    }
}
