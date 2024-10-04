using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly ExpenseDbContext _context;

    public ExpenseController(ExpenseDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetExpenses()
    {
        var expenses = _context.Expenses.ToList();
        return Ok(expenses);
    }

    [HttpPost]
    public IActionResult AddExpense([FromBody] Expense expense)
    {
        _context.Expenses.Add(expense);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
    }
}