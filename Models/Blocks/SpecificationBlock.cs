using System.ComponentModel.DataAnnotations;

namespace alloy_docker.Models.Blocks;

[ContentType(DisplayName = "SpecificationBlock", GUID = "b6a6fc77-a7f0-4ab9-adc5-18a5ae9f9dab", Description = "")]
public class SpecificationBlock : BlockData
{
    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 1)]
    public virtual string Key { get; set; }

    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string Name { get; set; }

    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 3)]
    public virtual XhtmlString SpecificationDetails { get; set; }
}