using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oxxy.SelectiveProcess.Vehicle.Api.Data.ValueObject;
using Oxxy.SelectiveProcess.Vehicle.Api.Model.Context;

namespace Oxxy.SelectiveProcess.Vehicle.Api.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        SqlServerContext _context;
        IMapper _mapper;

        public VehicleRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleVO>> FindAll()
        {
            List<Model.Vehicle> vehicles = await _context.Vehicles.ToListAsync();
            return _mapper.Map<List<VehicleVO>>(vehicles);
        }

        public async Task<VehicleVO> FindById(long id)
        {
            Model.Vehicle vehicle = await _context.Vehicles.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<VehicleVO>(vehicle);
        }

        public async Task<VehicleVO> Create(VehicleVO vo)
        {
            Model.Vehicle vehicle = _mapper.Map<Model.Vehicle>(vo);
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return _mapper.Map<VehicleVO>(vehicle);
        }

        public async Task<VehicleVO> Update(VehicleVO vo)
        {
            Model.Vehicle vehicle = _mapper.Map<Model.Vehicle>(vo);
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
            return _mapper.Map<VehicleVO>(vehicle);
        }

        public async Task<bool> Delete(long id)
        {
            Model.Vehicle vehicle = await _context.Vehicles.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (vehicle == null) return false;

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
