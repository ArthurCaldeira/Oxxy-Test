using Oxxy.SelectiveProcess.Web.Models;
using Oxxy.SelectiveProcess.Web.Services.IServices;
using Oxxy.SelectiveProcess.Web.Utils;

namespace Oxxy.SelectiveProcess.Web.Services
{
    public class VehicleImageService : IVehicleImageService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/VehicleImage";

        public VehicleImageService(HttpClient client)
        {
            _client = client;
        }

        public async Task<VehicleImageModel> Get(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<VehicleImageModel>();
        }

        public async Task<IEnumerable<VehicleImageModel>> GetByVehicle(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/Vehicle/{id}");
            return await response.ReadContentAs<IEnumerable<VehicleImageModel>>();
        }

        public async Task<VehicleImageModel> Create(VehicleImageModel vo)
        {
            var response = await _client.PostAsJsonAsync(BasePath, vo);
            return await response.ReadContentAs<VehicleImageModel>();
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<bool>();
        }

        public async Task<bool> DeleteByVehicle(int id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/Vehicle/{id}");
            return await response.ReadContentAs<bool>();
        }
    }
}
