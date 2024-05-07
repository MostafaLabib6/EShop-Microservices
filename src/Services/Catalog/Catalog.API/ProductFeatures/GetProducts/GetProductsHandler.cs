namespace Catalog.API.ProductFeatures.GetProducts;

public record GetProductsQuery : IQuery<GetProductsResponse>;
public record GetProductsResponse(IReadOnlyList<Product> Products);
internal class GetProductsHandler(IDocumentSession _session, ILogger<GetProductsHandler> _logger) : IQueryHandler<GetProductsQuery, GetProductsResponse>
{

	Task<GetProductsResponse> IRequestHandler<GetProductsQuery, GetProductsResponse>.Handle(GetProductsQuery query, CancellationToken cancellationToken)
	{
		_logger.LogInformation("GetProductsHandler.Handle with {@query}", query);

		var products = _session.Query<Product>().ToList();

		//var productDtos = products.Adapt<IReadOnlyList<ProductDto>>();

		return Task.FromResult(new GetProductsResponse(products)); // valid case case products already has a value not waiting for it.
	}
}
