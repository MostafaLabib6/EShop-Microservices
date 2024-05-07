namespace Catalog.API.ProductFeatures.GetProductByid
{
	public class GetProductByIdEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("Products/{Id}", async (Guid Id, IMediator sender) =>
			{
				var product = await sender.Send(new GetProductByIdQuery(Id));

				return Results.Ok(product);
			}).WithName("GetProductById")
		.Produces<ProductDto>(StatusCodes.Status200OK)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Get Product by Id")
		.WithDescription("Get Product by Id");
		}
	}
}
