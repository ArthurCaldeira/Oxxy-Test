using Oxxy.SelectiveProcess.Web.Models;

namespace Oxxy.SelectiveProcess.Web.Services.IServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleModel>> FindAllVehicles();
        Task<VehicleModel> FindVehicleById(int id);
        Task<VehicleModel> CreateVehicle(VehicleModel vo);
        Task<VehicleModel> UpdateVehicle(VehicleModel vo);
        Task<bool> DeleteVehicle(long id);
    }
}
