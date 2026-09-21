using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.DTOs;

namespace BackendForDiploma.Api.Mappers
{
    public static class PointMapper
    {
        public static PointDto ToDto(Point p)
        {
            return new PointDto(p.Id, p.BuildingId, p.SphereObjectName, p.X, p.Y, p.Z, p.CurrentColor);
        }
    }
}
