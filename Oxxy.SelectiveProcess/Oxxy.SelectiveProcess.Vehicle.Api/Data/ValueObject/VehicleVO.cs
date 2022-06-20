namespace Oxxy.SelectiveProcess.Vehicle.Api.Data.ValueObject
{
    public class VehicleVO
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string License { get; set; }
        public string OwnerName { get; set; }
        public string OwnerCPF { get; set; }
        public bool IsLocked { get; set; }
    }
}
