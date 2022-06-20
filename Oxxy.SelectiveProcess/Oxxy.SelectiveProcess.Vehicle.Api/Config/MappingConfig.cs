using AutoMapper;
using Oxxy.SelectiveProcess.Vehicle.Api.Data.ValueObject;

namespace Oxxy.SelectiveProcess.Vehicle.Api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VehicleVO, Model.Vehicle>();
                config.CreateMap<Model.Vehicle, VehicleVO>();
            });

            return mappingConfig;
        }
    }
}
