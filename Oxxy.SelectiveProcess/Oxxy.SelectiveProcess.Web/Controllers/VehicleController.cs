using Microsoft.AspNetCore.Mvc;
using Oxxy.SelectiveProcess.Web.Models;
using Oxxy.SelectiveProcess.Web.Services.IServices;

namespace Oxxy.SelectiveProcess.Web.Controllers
{
    public class VehicleController : Controller
    {
        IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleService.FindAllVehicles();
            return View(vehicles);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vehicleService.CreateVehicle(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Open(int id)
        {
            var model = await _vehicleService.FindVehicleById(id);
            if (model != null) return View(model);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Open(VehicleModel model)
        {
            var vehicle = await _vehicleService.FindVehicleById(model.Id);
            if (vehicle != null) return RedirectToAction("Update", new { id = vehicle.Id });
            return NotFound();
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _vehicleService.FindVehicleById(id);
            if (model != null) return View(model);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(VehicleModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vehicleService.UpdateVehicle(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                var model = await _vehicleService.FindVehicleById(id);
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VehicleModel model)
        {
            var response = await _vehicleService.DeleteVehicle(model.Id);
            
            if (response) return RedirectToAction(nameof(Index));
            
            return View(model);
        }
    }
}
