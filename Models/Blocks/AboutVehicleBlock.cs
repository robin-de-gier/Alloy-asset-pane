using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace alloy_docker.Models.Blocks;

[ContentType(DisplayName = "AboutVehicleBlock", GUID = "ce9e42f5-248c-4603-9f27-05e4d5c3a5e8", Description = "")]
public class AboutVehicleBlock
{
    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 1)]
    public virtual string Title { get; set; }

    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string Subtitle { get; set; }

    [UIHint(UIHint.Textarea)]
    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 10)]
    public virtual string Description { get; set; }

    [Display(GroupName = SystemTabNames.Content, Order = 20)]
    public virtual ContentReference Image { get; set; }

    [Display(GroupName = SystemTabNames.Content, Order = 30)]
    public virtual string CtaText { get; set; }

    [Display(GroupName = SystemTabNames.Content, Order = 40)]
    public virtual Url CtaLink { get; set; }

    [Display(GroupName = SystemTabNames.Content, Order = 41)]
    public virtual bool OpenCtaInNewWindow { get; set; }
}