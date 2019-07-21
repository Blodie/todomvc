using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllTodosController : ControllerBase
    {
        private readonly TodoContext _context;

        public AllTodosController(TodoContext context)
        {
            _context = context;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCompletedItems()
        {
            var completedTasks = _context.TodoItems.Where(item => item.IsComplete);
            _context.TodoItems.RemoveRange(completedTasks);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}