namespace Catalog.API.ProductFeatures.GetProducts;

public class GetProductsEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/products",
			async (IMediator sender) =>
			{
				var result = await sender.Send(new GetProductsQuery());
				return Results.Ok(result);
			}).WithDisplayName("GetProducts")
			.Produces<GetProductsResponse>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status400BadRequest)
			.WithDescription("Get Products")
			.WithSummary("Get Products");

	}
}
