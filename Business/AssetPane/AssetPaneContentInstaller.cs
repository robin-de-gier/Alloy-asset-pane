using alloy_docker.Models.Blocks;
using alloy_docker.Models.Folders;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.Web;
using System.Globalization;

namespace alloy_docker.Business.AssetPane;

public class AssetPaneContentInstaller : IBlockingFirstRequestInitializer
{
    private readonly ContentRootService _contentRootService;
    private readonly IContentRepository _contentRepository;

    public AssetPaneContentInstaller(ContentRootService contentRootService, IContentRepository contentRepository)
    {
        _contentRootService = contentRootService;
        _contentRepository = contentRepository;
    }

    public bool CanRunInParallel => false;

    public Task InitializeAsync(HttpContext httpContext)
    {
        _contentRootService.Register<ContentFolder>(AssetPaneSettings.ProviderName,
            AssetPaneSettings.ProviderGuid, ContentReference.RootPage);

        var root = _contentRepository.Get<ContentFolder>(AssetPaneSettings.ProviderGuid);
        var children = _contentRepository
            .GetChildren<ContentFolder>(root.ContentLink)
            .ToList();

        CreateSpecificFolder<HighlightContentFolder>(AssetPaneSettings.HighlightsFolderName, root.ContentLink,
            children);
        CreateSpecificFolder<SpecificationContentFolder>(AssetPaneSettings.SpecificationsFolderName,
            root.ContentLink, children);

        CreateInitialVehicleInformationFolders(root.ContentLink, children);

        InitSpecifications();

        return Task.CompletedTask;
    }

    private void CreateInitialVehicleInformationFolders(ContentReference parentFolder, List<ContentFolder> children)
    {
        if (children.Any(child => child.Name == AssetPaneSettings.VehicleInformationFolderName))
        {
            return;
        }

        var root = CreateSpecificFolder<ContentFolder>(AssetPaneSettings.VehicleInformationFolderName,
            parentFolder, children);

        var seat = CreateSpecificFolder<ContentFolder>("Seat", root);
        CreateSpecificFolder<ContentFolder>("IBIZA", seat);
    }

    private ContentReference CreateSpecificFolder<T>(string folderName, ContentReference parentFolder,
        List<ContentFolder> children) where T : IContent
    {
        if (children.Any(child => child.Name == folderName))
        {
            return null;
        }

        var folder = _contentRepository.GetDefault<T>(parentFolder);
        folder.Name = folderName;
        return _contentRepository.Save(folder, SaveAction.Publish, AccessLevel.NoAccess);
    }

    private ContentReference CreateSpecificFolder<T>(string folderName, ContentReference parentFolder)
        where T : IContent
    {
        var folder = _contentRepository.GetDefault<T>(parentFolder);
        folder.Name = folderName;
        return _contentRepository.Save(folder, SaveAction.Publish, AccessLevel.NoAccess);
    }

    private void InitSpecifications()
    {
        var root = _contentRepository.Get<ContentFolder>(AssetPaneSettings.ProviderGuid);
        var children = _contentRepository.GetChildren<ContentFolder>(root.ContentLink);
        var specificationsFolder = children.SingleOrDefault(c => c.Name == "Specifications");

        var specifications = _contentRepository.GetChildren<SpecificationBlock>(specificationsFolder.ContentLink);
        if (specifications != null && specifications.Any())
        {
            // Specifications already made, backout.
            return;
        }

        CreateSpecification("Milieulabel", "environmentalLabel", specificationsFolder);
        CreateSpecification("Uitstoot", "emission", specificationsFolder);
        CreateSpecification("Verbruik stad", "fuelEconomyCity", specificationsFolder);
        CreateSpecification("Verbruik snelweg", "fuelEconomyHighway", specificationsFolder);
        CreateSpecification("Verbruik gemiddeld", "fuelEconomyCombined", specificationsFolder);
        CreateSpecification("Vermogen", "power", specificationsFolder);
        CreateSpecification("Torque", "torque", specificationsFolder);
        CreateSpecification("Aantal cilinders", "numberOfCilinders", specificationsFolder);
        CreateSpecification("Cilinderinhoud", "cilinderCapacity", specificationsFolder);
        CreateSpecification("Top snelheid", "maxSpeed", specificationsFolder);
        CreateSpecification("Acceleratie", "acceleration", specificationsFolder);
        CreateSpecification("Transmissie", "drive", specificationsFolder);
        CreateSpecification("Aantal versnellingen", "numberOfGears", specificationsFolder);
        CreateSpecification("Tank inhoud", "fuelCapacity", specificationsFolder);
        CreateSpecification("Hoogte", "height", specificationsFolder);
        CreateSpecification("Breedte", "width", specificationsFolder);
        CreateSpecification("Lengte", "length", specificationsFolder);
        CreateSpecification("Minimaal bagage ruimte", "cargoSpaceMin", specificationsFolder);
        CreateSpecification("Maximaal bagage ruimte", "cargoSpaceMax", specificationsFolder);
        CreateSpecification("Draaicirkel", "turningRadius", specificationsFolder);
        CreateSpecification("Trekkracht ongeremd", "towingCapacityUnbraked", specificationsFolder);
        CreateSpecification("Trekkracht geremd", "towingCapacityBraked", specificationsFolder);
        CreateSpecification("Leeg gewicht", "weightEmpty", specificationsFolder);
        CreateSpecification("Max gewicht", "weightMax", specificationsFolder);
        CreateSpecification("Laad capaciteit", "loadingCapacity", specificationsFolder);
        CreateSpecification("Maximaal dak gewicht", "maxRoofLoad", specificationsFolder);
    }

    private void CreateSpecification(string name, string key, ContentFolder contentFolder)
    {
        var specification =
            _contentRepository.GetDefault<SpecificationBlock>(contentFolder.ContentLink, new CultureInfo("nl"));
        ((IContent) specification).Name = name;
        specification.Key = key;
        var reference = _contentRepository.Save((IContent) specification, SaveAction.Publish, AccessLevel.NoAccess);
        
        specification =
            _contentRepository.CreateLanguageBranch<SpecificationBlock>(reference, new CultureInfo("en"));
        ((IContent) specification).Name = name;
        specification.Key = key;
        _contentRepository.Save((IContent) specification, SaveAction.Publish, AccessLevel.NoAccess);
    }
}