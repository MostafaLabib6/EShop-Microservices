namespace Catalog.API.ProductFeatures.GetProductByCategory
{
	public class GetProductByCategoryEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("Products/Category/{Category}", async (string Category, IMediator sender) =>
			{
				var products = await sender.Send(new GetProductByCategoryQuery(Category));

				return Results.Ok(products);
			}).WithName("GetProductByCategory")
			.Produces<List<ProductDto>>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status400BadRequest)
			.WithSummary("Get Product by Category")
			.WithDescription("Get Product by Category");
		}
	}
}
