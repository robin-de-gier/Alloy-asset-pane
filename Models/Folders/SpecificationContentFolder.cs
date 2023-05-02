using alloy_docker.Models.Blocks;

namespace alloy_docker.Models.Folders;

[ContentType(GUID = "5ef8be93-d6b6-4f32-93c1-7699e2fdafe1")]
[AvailableContentTypes(Availability.Specific, Include = new[] {typeof(SpecificationBlock)})]
public class SpecificationContentFolder : ContentFolder
{
}