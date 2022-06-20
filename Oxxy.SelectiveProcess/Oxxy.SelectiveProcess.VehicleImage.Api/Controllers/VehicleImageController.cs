using Microsoft.AspNetCore.Mvc;
using Oxxy.SelectiveProcess.VehicleImage.Api.Data.ValueObject;
using Oxxy.SelectiveProcess.VehicleImage.Api.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oxxy.SelectiveProcess.VehicleImage.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehicleImageController : ControllerBase
    {
        IVehicleImageRepository _repository;

        public VehicleImageController(IVehicleImageRepository repository)
        {
            _repository = repository;
        }

        // GET api/<VehicleImageController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleImageVO>> Get(int id)
        {
            var vehicleImage = await _repository.Get(id);

            if (vehicleImage == null) return NotFound();
            return Ok(vehicleImage);
        }

        // GET api/<VehicleImageController>/vehicle/5
        [HttpGet("vehicle/{Id}")]
        public async Task<ActionResult<IEnumerable<VehicleImageVO>>> GetByVehicle(int id)
        {
            var vehicleImages = await _repository.GetByVehicle(id);

            if (vehicleImages == null) return NotFound();
            return Ok(vehicleImages);
        }

        // POST api/<VehicleImageController>
        [HttpPost]
        public async Task<ActionResult<VehicleImageVO>> Post([FromBody] VehicleImageVO vo)
        {
            if (vo == null) return BadRequest();

            var vehicleImageVO = await _repository.Create(vo);
            return Ok(vehicleImageVO);

        }

        // DELETE api/<VehicleImageController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var status = await _repository.Delete(id);

            if (!status) return BadRequest();
            return Ok(status);
        }

        // DELETE api/<VehicleImageController>/Vehicle/5
        [HttpDelete("Vehicle/{id}")]
        public async Task<ActionResult<bool>> DeleteByVehicle(int id)
        {
            var status = await _repository.DeleteByVehicle(id);

            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
