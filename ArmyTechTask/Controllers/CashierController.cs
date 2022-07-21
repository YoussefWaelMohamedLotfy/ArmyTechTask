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
                Cashiers = await _unit.Cashiers.GetAllCashiersWithBranch()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(long? id)
        {
            CashierUpsertVM viewModel = new()
            {
                BranchSelectList = _unit.Cashiers.GetAllBranchesDropdownList()
            };

            if (id is null)
            {
                // Create
                viewModel.Cashier = new();
            }
            else
            {
                // Update
                viewModel.Cashier = await _unit.Cashiers.GetCashierByIdAsync(id.Value);

                if (viewModel.Cashier is null)
                    return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CashierUpsertVM viewModel)
        {
            if (viewModel.Cashier.Id == 0)
            {
                await _unit.Cashiers.AddAsync(viewModel.Cashier);
            }
            else
            {
                _unit.Cashiers.Update(viewModel.Cashier);
            }

            await _unit.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCashier(long id)
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
