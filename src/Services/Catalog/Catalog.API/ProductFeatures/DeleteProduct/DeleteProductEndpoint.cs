namespace Catalog.API.ProductFeatures.DeleteProduct;

public class DeleteProductEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapDelete("/products/{ProductId}",
			async (Guid ProductId, IMediator sender) =>
			{
				await sender.Send(new DeleteProductCommand(ProductId));
				return Results.NoContent();
			}
			).WithDisplayName("DeleteProduct")
			.Produces(StatusCodes.Status204NoContent)
			.ProducesProblem(StatusCodes.Status400BadRequest)
			.WithDescription("Delete Product")
			.WithSummary("Delete Product");
	}
}
