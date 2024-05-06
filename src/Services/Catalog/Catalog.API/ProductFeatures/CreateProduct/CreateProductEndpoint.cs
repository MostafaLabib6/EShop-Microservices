namespace Catalog.API.Products.CreateProduct;

public class CreateProductEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/products",
			async (ProductDto request, IMediator sender) =>
			{

				var product = await sender.Send(new CreateProductCommand(request));

				//return Results.Created($"/products/{result}", result);
				return Results.CreatedAtRoute("GetProductById", new { id = product }, product);

			})
		.WithName("CreateProduct")
		.Produces<ProductDto>(StatusCodes.Status201Created)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Create Product")
		.WithDescription("Create Product");
	}
}