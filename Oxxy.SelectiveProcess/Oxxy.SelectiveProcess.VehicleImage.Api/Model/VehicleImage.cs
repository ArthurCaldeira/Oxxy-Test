using Oxxy.SelectiveProcess.VehicleImage.Api.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oxxy.SelectiveProcess.VehicleImage.Api.Model
{
    public class VehicleImage: BaseEntity
    {
        [Column("vehicle_id")]
        [Required]
        public int VehicleId { get; set; }

        [Column("image_data")]
        [Required]
        public byte[] ImageData { get; set; }
    }
}
