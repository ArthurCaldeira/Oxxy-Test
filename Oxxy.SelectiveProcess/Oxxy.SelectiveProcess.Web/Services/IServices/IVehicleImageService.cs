using Oxxy.SelectiveProcess.Web.Models;

namespace Oxxy.SelectiveProcess.Web.Services.IServices
{
    public interface IVehicleImageService
    {
        Task<VehicleImageModel> Get(int id);
        Task<IEnumerable<VehicleImageModel>> GetByVehicle(int id);
        Task<VehicleImageModel> Create(VehicleImageModel vo);
        Task<bool> Delete(int id);
        Task<bool> DeleteByVehicle(int id);
    }
}
