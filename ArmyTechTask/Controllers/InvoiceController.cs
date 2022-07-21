using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArmyTechTask.Controllers;

public class InvoiceController : Controller
{
    private readonly IUnitOfWork _unit;

    public InvoiceController(IUnitOfWork unit)
    {
        _unit = unit ?? throw new ArgumentNullException(nameof(unit));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        InvoiceIndexVM viewModel = new()
        {
            Invoices = await _unit.Invoices.GetAllAsync()
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> DetailsEdit(long id)
    {
        InvoiceDetailsEditVM viewModel = new()
        {
            Invoice = await _unit.InvoiceHeaders.GetInvoiceHeadersWithRelations(id),
            BranchSelectList = _unit.Invoices.GetAllBranchesDropdownList(),
            CashierSelectList = _unit.Invoices.GetAllCashiersDropdownList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> DetailsEdit(InvoiceDetailsEditVM viewModel)
    {
        _unit.InvoiceHeaders.Update(viewModel.Invoice);
        await _unit.SaveAsync();

        return RedirectToAction(nameof(Index));
    }
}
