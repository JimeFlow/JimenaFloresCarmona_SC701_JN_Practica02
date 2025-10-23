using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SC701_JN_Practica02.Data;
using SC701_JN_Practica02.Models;

namespace SC701_JN_Practica02.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly VehiculoRepository _repoVeh;
        private readonly VendedorRepository _repoVen;
        public VehiculoController(VehiculoRepository repoVeh, VendedorRepository repoVen)
        {
            _repoVeh = repoVeh;
            _repoVen = repoVen;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vendedores = await _repoVen.GetAllAsync();
            ViewBag.Vendedores = new SelectList(vendedores, "Cedula", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehiculoModel model)
        {
            if (!ModelState.IsValid)
            {
                var vendedores = await _repoVen.GetAllAsync();
                ViewBag.Vendedores = new SelectList(vendedores, "Cedula", "Nombre", model.VendedorCedula);
                return View(model);
            }

            try
            {
                await _repoVeh.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pudo registrar el vehículo: " + ex.Message);
                var vendedores = await _repoVen.GetAllAsync();
                ViewBag.Vendedores = new SelectList(vendedores, "Cedula", "Nombre", model.VendedorCedula);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _repoVeh.GetAllWithVendedorAsync();
            return View(list);
        }
    }
}
