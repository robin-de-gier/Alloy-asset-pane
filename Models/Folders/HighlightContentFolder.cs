using alloy_docker.Models.Blocks;

namespace alloy_docker.Models.Folders;

[ContentType(GUID = "a4d6f7e7-ff75-4345-b0fc-2a3488ea1fde")]
[AvailableContentTypes(Availability.Specific, Include = new[] {typeof(HighlightBlock)})]
public class HighlightContentFolder : ContentFolder
{
}