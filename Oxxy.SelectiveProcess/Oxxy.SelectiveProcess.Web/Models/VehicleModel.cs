namespace Oxxy.SelectiveProcess.Web.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string License { get; set; }
        public string OwnerName { get; set; }
        public string OwnerCPF { get; set; }
        public bool IsLocked { get; set; }
        public List<VehicleImageModel> VehicleImages { get; set; }
    }
}
