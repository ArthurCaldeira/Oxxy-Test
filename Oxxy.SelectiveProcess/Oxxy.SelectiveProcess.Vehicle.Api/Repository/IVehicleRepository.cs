using Oxxy.SelectiveProcess.Vehicle.Api.Data.ValueObject;

namespace Oxxy.SelectiveProcess.Vehicle.Api.Repository
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<VehicleVO>> FindAll();
        Task<VehicleVO> FindById(long id);
        Task<VehicleVO> Create(VehicleVO vo);
        Task<VehicleVO> Update(VehicleVO vo);
        Task<bool> Delete(long id);
    }
}
