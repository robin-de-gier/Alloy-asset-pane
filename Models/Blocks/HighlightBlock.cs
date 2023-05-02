using EPiServer.Shell.ObjectEditing;
using System.ComponentModel.DataAnnotations;

namespace alloy_docker.Models.Blocks;

[ContentType(DisplayName = "HighlightBlock", GUID = "48fc3d76-6f64-4f1d-b0a2-f3eb4494e0b0")]
public class HighlightBlock
{
    [Display(GroupName = SystemTabNames.Content, Order = 1)]
    public virtual string Key { get; set; }

    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string Name { get; set; }

    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 3)]
    public virtual string Description { get; set; }

    [Display(GroupName = SystemTabNames.Content, Order = 5)]
    public virtual ContentReference Image { get; set; }

    [Display(GroupName = SystemTabNames.Content, Order = 6)]
    public virtual int Order { get; set; }

    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 7)]
    public virtual XhtmlString SpecificationDetails { get; set; }
}