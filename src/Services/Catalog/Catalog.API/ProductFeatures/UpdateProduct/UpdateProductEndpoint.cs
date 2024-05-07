namespace Catalog.API.ProductFeatures.UpdateProduct
{
	public class UpdateProductEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPut("/products",
				async (UpdateProductCommand request, IMediator sender) =>
				{
					await sender.Send(new UpdateProductCommand(request.Product));
					return Results.NoContent();
				}).WithDisplayName("UpdateProduct")
				.Produces(StatusCodes.Status204NoContent)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.WithDescription("Update Product")
				.WithSummary("Update Product");
		}

	}
}
