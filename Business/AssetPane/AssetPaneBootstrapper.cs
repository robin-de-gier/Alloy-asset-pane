using EPiServer.Web;

namespace alloy_docker.Business.AssetPane;

/// <summary>
/// Bootstrapper used to initialize the Asset Pane menu and the content folders in it.
/// This bootstrapper creates, or loads, the underlying menu and makes it available in the Optimizely UI.
/// </summary>
public static class AssetPaneBootstrapper
{
    public static IServiceCollection AddAssetPaneContent(this IServiceCollection services)
        => services.AddSingleton<IFirstRequestInitializer, AssetPaneContentInstaller>();
}