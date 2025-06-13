using AutoMapper;
using PersonalFinancialSystem.Data.Dtos;
using PersonalFinancialSystem.Models;

namespace PersonalFinancialSystem.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, ReadCategoryDto>();
            //CreateMap<ICollection<Category>, ICollection<ReadCategoryDto>>();
        }
    }
}
