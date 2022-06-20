using Oxxy.SelectiveProcess.Web.Models;
using Oxxy.SelectiveProcess.Web.Services.IServices;
using Oxxy.SelectiveProcess.Web.Utils;

namespace Oxxy.SelectiveProcess.Web.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Vehicle";

        public VehicleService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<VehicleModel>> FindAllVehicles()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<VehicleModel>>();
        }

        public async Task<VehicleModel> FindVehicleById(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<VehicleModel>();
        }

        public async Task<VehicleModel> CreateVehicle(VehicleModel vo)
        {
            var response = await _client.PostAsJsonAsync(BasePath, vo);
            return await response.ReadContentAs<VehicleModel>();
        }

        public async Task<VehicleModel> UpdateVehicle(VehicleModel vo)
        {
            var response = await _client.PutAsJsonAsync(BasePath, vo);
            return await response.ReadContentAs<VehicleModel>();
        }

        public async Task<bool> DeleteVehicle(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<bool>();
        }
    }
}
