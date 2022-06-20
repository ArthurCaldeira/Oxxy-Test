using Microsoft.AspNetCore.Mvc;
using Oxxy.SelectiveProcess.Vehicle.Api.Data.ValueObject;
using Oxxy.SelectiveProcess.Vehicle.Api.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oxxy.SelectiveProcess.Vehicle.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        IVehicleRepository _repository;

        public VehicleController(IVehicleRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        // GET: api/v1/<VehicleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleVO>>> GetAllVehiclesAsync()
        {
            var vehicles = await _repository.FindAll();
            return Ok(vehicles);
        }

        // GET api/v1/<VehicleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleVO>> GetAsync(int id)
        {
            var vehicle = await _repository.FindById(id);

            if (vehicle == null) return NotFound();
            return Ok(vehicle);
        }

        // POST api/v1/<VehicleController>
        [HttpPost]
        public async Task<ActionResult<VehicleVO>> Post([FromBody] VehicleVO vo)
        {
            if (vo == null) return BadRequest();

            var vehicle = await _repository.Create(vo);

            return Ok(vehicle);
        }

        // PUT api/v1/<VehicleController>
        [HttpPut]
        public async Task<ActionResult<VehicleVO>> Put([FromBody] VehicleVO vo)
        {
            if (vo == null) return BadRequest();

            var vehicle = await _repository.Update(vo);

            return Ok(vehicle);
        }

        // DELETE api/v1/<VehicleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await _repository.Delete(id);

            if (!status) return BadRequest();

            return Ok(status);
        }
    }
}
