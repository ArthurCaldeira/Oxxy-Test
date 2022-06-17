using Oxxy.SelectiveProcess.Vehicle.Api.Data.ValueObject;

namespace Oxxy.SelectiveProcess.Vehicle.Api.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        public Task<VehicleVO> Create(VehicleVO vo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleVO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleVO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleVO> Update(VehicleVO vo)
        {
            throw new NotImplementedException();
        }
    }
}
