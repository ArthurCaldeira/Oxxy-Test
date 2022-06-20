namespace Oxxy.SelectiveProcess.Web.Models
{
    public class VehicleImageModel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public byte[] ImageData { get; set; }
    }
}
