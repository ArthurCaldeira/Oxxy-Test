using AutoMapper;
using Oxxy.SelectiveProcess.VehicleImage.Api.Data.ValueObject;

namespace Oxxy.SelectiveProcess.VehicleImage.Api.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                object p = config.CreateMap<VehicleImageVO, Model.VehicleImage>();
                config.CreateMap<Model.VehicleImage, VehicleImageVO>();
            });

            return mappingConfig;
        }
    }
}
