using Microsoft.AspNetCore.Mvc;
using Oxxy.SelectiveProcess.Web.Models;
using Oxxy.SelectiveProcess.Web.Services.IServices;
using System.Text;

namespace Oxxy.SelectiveProcess.Web.Controllers
{
    public class VehicleController : Controller
    {
        IVehicleService _vehicleService;
        IVehicleImageService _vehicleImageService;

        public VehicleController(IVehicleService vehicleService, IVehicleImageService vehicleImageService)
        {
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            _vehicleImageService = vehicleImageService ?? throw new ArgumentNullException(nameof(vehicleImageService));
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
            var response = await _vehicleService.CreateVehicle(model);
            if (response != null) return RedirectToAction(nameof(Update), new { id = response.Id });
         
            return View(model);
        }

        public async Task<IActionResult> Open(int id)
        {
            var model = await _vehicleService.FindVehicleById(id);
            var vehicleImages = await _vehicleImageService.GetByVehicle(id);

            model.VehicleImages = vehicleImages.ToList();

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

            var vehicleImages = await _vehicleImageService.GetByVehicle(id);

            model.VehicleImages = vehicleImages.ToList();

            if (model != null) return View(model);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(VehicleModel model)
        {
            var response = await _vehicleService.UpdateVehicle(model);
            if (response != null) return RedirectToAction(nameof(Index));

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                var model = await _vehicleService.FindVehicleById(id);

                var vehicleImages = await _vehicleImageService.GetByVehicle(id);

                model.VehicleImages = vehicleImages.ToList();

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VehicleModel model)
        {
            var response = await _vehicleService.DeleteVehicle(model.Id);
            var responseImage = await _vehicleImageService.DeleteByVehicle(model.Id);

            if (response) return RedirectToAction(nameof(Index));
            
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveFile(IFormFile file, int id)
        {
            //if (choosenImage == null) throw new ArgumentNullException(nameof(choosenImage));

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var response = await _vehicleImageService.Create(new VehicleImageModel() { VehicleId = id, ImageData = fileBytes });
                //string s = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
            }

            

            return RedirectToAction("Update", new { id });
        }
    }
}
