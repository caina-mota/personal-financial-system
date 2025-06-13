using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinancialSystem.Data.Dtos;
using PersonalFinancialSystem.Services;

namespace PersonalFinancialSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private ExpensesService _expensesService;

        public ExpensesController(ExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpPost]
        public IActionResult CreateExpense([FromBody] CreateExpenseDto dto)
        {
            var userIdClaim = User.FindFirst("Id")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            var expense = _expensesService.CreateExpense(dto, userId);            

            return CreatedAtAction(nameof(GetById), new { id = expense }, null);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            ReadExpenseDto expense = _expensesService.FindById(id);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }
    }
}
