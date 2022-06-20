using Oxxy.SelectiveProcess.VehicleImage.Api.Data.ValueObject;
using System.Collections.Generic;

namespace Oxxy.SelectiveProcess.VehicleImage.Api.Repository
{
    public interface IVehicleImageRepository
    {
        Task<VehicleImageVO> Get(int id);
        Task<IEnumerable<VehicleImageVO>> GetByVehicle(int id);
        Task<VehicleImageVO> Create(VehicleImageVO vo);
        Task<bool> Delete(int id);
        Task<bool> DeleteByVehicle(int id);

    }
}
