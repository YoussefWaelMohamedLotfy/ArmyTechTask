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

    public async Task<IActionResult> Index()
    {
        InvoiceIndexVM viewModel = new()
        {
            Invoices = await _unit.Invoices.GetAllAsync()
        };

        return View(viewModel);
    }
}
