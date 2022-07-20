using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArmyTechTask.Controllers
{
    public class CashierController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CashierController(IUnitOfWork unit)
        {
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CashierIndexVM viewModel = new()
            {
                Cashiers = await _unit.Cashiers.GetAllAsync()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            CashierEditVM viewModel = new()
            {
                Cashiers = await _unit.Cashiers.GetCashierByIdAsync(id)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            var cashier = await _unit.Cashiers.GetCashierByIdAsync(id);

            if (cashier is null)
                return NotFound();

            _unit.Cashiers.Delete(cashier);
            await _unit.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
