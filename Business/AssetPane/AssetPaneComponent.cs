using EPiServer.Shell;
using EPiServer.Shell.ViewComposition;

namespace alloy_docker.Business.AssetPane;

public class AssetPaneComponent : ComponentDefinitionBase
{
    public AssetPaneComponent()
        : base("epi-cms/asset/HierarchicalList")
    {
        Categories = new[] {"content"};
        Title = AssetPaneSettings.ProviderName;
        Description = "List Bynco content";
        SortOrder = 900;
        PlugInAreas = new[] {PlugInArea.AssetsDefaultGroup, PlugInArea.NavigationDefaultGroup};
        Settings.Add(new Setting("repositoryKey", value: AssetPaneSettings.ProviderKey));
    }
}