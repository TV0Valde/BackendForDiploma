using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.DTOs;

namespace BackendForDiploma.Api.Mappers
{
    public class BuildingMapper
    {
        public static BuildingDto ToDto(Building b) =>
       new(b.Id, b.Name, b.Description, b.ModelObjectKey, b.ModelFormat, b.CreatedAt);
    }
}
