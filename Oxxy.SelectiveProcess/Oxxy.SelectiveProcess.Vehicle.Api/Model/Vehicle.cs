using Oxxy.SelectiveProcess.Vehicle.Api.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oxxy.SelectiveProcess.Vehicle.Api.Model
{
    public class Vehicle: BaseEntity
    {
        [Column("license_plate")]
        [Required]
        [StringLength(8)]
        public string LicensePlate { get; set; }

        [Column("license")]
        [Required]
        [StringLength(11)]
        public string License { get; set; }

        [Column("owner_name")]
        [Required]
        [StringLength(150)]
        public string OwnerName { get; set; }

        [Column("owner_cpf")]
        [Required]
        [StringLength(14)]
        public string OwnerCPF { get; set; }

    }
}
