namespace Catalog.API.Dtos;
public record ProductDto(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
