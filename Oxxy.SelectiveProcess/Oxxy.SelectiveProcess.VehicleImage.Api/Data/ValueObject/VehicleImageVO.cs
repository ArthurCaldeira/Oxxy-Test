namespace Oxxy.SelectiveProcess.VehicleImage.Api.Data.ValueObject
{
    public class VehicleImageVO
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public byte[] ImageData { get; set; }
    }
}
