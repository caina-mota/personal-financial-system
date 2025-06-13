using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PersonalFinancialSystem.Data.Dtos;
using PersonalFinancialSystem.Models;
using PersonalFinancialSystem.Services;

namespace PersonalFinancialSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            try
            {
                var category = await _categoryService.CreateCategory(dto);

                var output = _categoryService.FindById(category.Id);

                return CreatedAtAction(nameof(GetById), new { id = category.Id }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id) 
        {
            if (!Guid.TryParse(id, out var categoryId))
            {
                return BadRequest();
            } 

            ReadCategoryDto dto = _categoryService.FindById(categoryId);
            if (dto == null) { return NotFound(); }
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            ICollection<ReadCategoryDto> dtos = _categoryService.FindAll();
            if (dtos == null || dtos.Count < 1) { return NotFound(); }
            return Ok(dtos);
        }
    }
}
