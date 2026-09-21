namespace BackendForDiploma.Api.DTOs
{
    public record PointRecordDto(Guid Id, Guid PointId, string PhotoObjectKey, string InspectionDate, string State);
    public record CreatePointRecordRequest(Guid? Id, string? PhotoObjectKey, string InspectionDate, string State);
    public record UpdatePointRecordRequest(string PhotoObjectKey, string InspectionDate, string State);
}