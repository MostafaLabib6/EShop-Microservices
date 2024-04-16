namespace Catalog.API.ProductFeatures.CreateProduct;

public record CreateProductDto(string Name, string Description, decimal Price, string ImageFile, List<int> CategoryIds);


public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/products", async (CreateProductDto product, ISender sender) =>
        {
            var command = product.Adapt<CreateProductDto>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();

            return Results.Created($"/products/{response.Id}", response);
        })
          .WithName("Create Product")
          .Produces<CreateProductResponse>(StatusCodes.Status201Created)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithDescription("Create a product");

    }
}
