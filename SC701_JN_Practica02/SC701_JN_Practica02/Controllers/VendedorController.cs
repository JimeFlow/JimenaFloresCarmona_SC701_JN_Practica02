using Microsoft.AspNetCore.Mvc;
using SC701_JN_Practica02.Data;
using SC701_JN_Practica02.Models;

namespace SC701_JN_Practica02.Controllers
{
    public class VendedorController : Controller
    {
        private readonly VendedorRepository _repo;
        public VendedorController(VendedorRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(VendedorModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                await _repo.CreateAsync(model);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Si la excepción proviene del SP por cédula duplicada, se muestra mensaje
                ModelState.AddModelError(string.Empty, "No se pudo registrar el vendedor: " + ex.Message);
                return View(model);
            }
        }
    }
}
