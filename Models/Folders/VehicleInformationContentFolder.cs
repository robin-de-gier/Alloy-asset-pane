using alloy_docker.Models.Blocks;

namespace alloy_docker.Models.Folders;

[ContentType(GUID = "4301521d-1a25-47d2-ba53-e0d2356a09b8")]
[AvailableContentTypes(Availability.Specific, Include = new[] {typeof(AboutVehicleBlock)})]
public class VehicleInformationContentFolder : ContentFolder
{
}