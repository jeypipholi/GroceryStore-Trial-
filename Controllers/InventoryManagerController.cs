using GroceryStore.Data;
using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStore.Controllers
{
    public class InventoryManagerController : Controller
    {
        private readonly ApplicationDbContext context;

        public InventoryManagerController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSupplier(Supplier supplier)
        {
            context.Add(supplier);
            await context.SaveChangesAsync();
            return RedirectToAction("AddSupplier");

        }
    }
}
