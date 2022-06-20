using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oxxy.SelectiveProcess.VehicleImage.Api.Data.ValueObject;
using Oxxy.SelectiveProcess.VehicleImage.Api.Model.Context;

namespace Oxxy.SelectiveProcess.VehicleImage.Api.Repository
{
    public class VehicleImageRepository : IVehicleImageRepository
    {
        SqlServerContext _context;
        IMapper _mapper;

        public VehicleImageRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VehicleImageVO> Get(int id)
        {
            Model.VehicleImage vehicleImage = await _context.VehicleImages.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<VehicleImageVO>(vehicleImage);
        }

        public async Task<IEnumerable<VehicleImageVO>> GetByVehicle(int id)
        {
            List<Model.VehicleImage> vehicleImages = await _context.VehicleImages.Where(x => x.VehicleId == id).ToListAsync();
            return _mapper.Map<IEnumerable<VehicleImageVO>>(vehicleImages);
        }

        public async Task<VehicleImageVO> Create(VehicleImageVO vo)
        {
            Model.VehicleImage vehicleImage = _mapper.Map<Model.VehicleImage>(vo);
            _context.VehicleImages.Add(vehicleImage);
            await _context.SaveChangesAsync();
            return vo;
        }

        public async Task<bool> Delete(int id)
        {
            Model.VehicleImage vehicleImage = await _context.VehicleImages.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (vehicleImage == null) return false;

            _context.Remove(vehicleImage);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByVehicle(int id)
        {
            List<Model.VehicleImage> vehicleImage = await _context.VehicleImages.Where(x => x.VehicleId == id).ToListAsync();

            if (vehicleImage == null || vehicleImage.Count == 0) return false;

            _context.RemoveRange(vehicleImage);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
