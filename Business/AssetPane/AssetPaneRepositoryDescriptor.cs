using EPiServer.Cms.Shell.UI.UIDescriptors;

namespace alloy_docker.Business.AssetPane;

public class AssetPaneRepositoryDescriptor : MediaRepositoryDescriptor
{
    private readonly ContentReference _root;

    public AssetPaneRepositoryDescriptor(ContentRootService contentRootService)
    {
        _root = contentRootService.Get(AssetPaneSettings.ProviderName);
    }

    private static string RepositoryKey => AssetPaneSettings.ProviderKey;

    public override string Key => RepositoryKey;

    public override string SearchArea => RepositoryKey;

    public override string Name => AssetPaneSettings.ProviderName;

    public override IEnumerable<ContentReference> Roots => new[] {_root};

    public override IEnumerable<Type> MainNavigationTypes => new[] {typeof(ContentFolder)};

    public override IEnumerable<Type> ContainedTypes => new[] {typeof(ContentFolder), typeof(BlockData)};

    public override IEnumerable<Type> CreatableTypes => new[] {typeof(ContentFolder), typeof(BlockData)};

    public override IEnumerable<Type> LinkableTypes => new[] {typeof(ContentFolder), typeof(BlockData)};
}