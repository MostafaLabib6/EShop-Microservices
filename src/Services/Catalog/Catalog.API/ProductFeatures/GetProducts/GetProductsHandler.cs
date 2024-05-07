namespace Catalog.API.ProductFeatures.GetProducts;

public record GetProductsQuery : IQuery<GetProductsResponse>;
public record GetProductsResponse(IEnumerable<Product> Products);
internal class GetProductsHandler(IDocumentSession _session, ILogger<GetProductsHandler> _logger) : IQueryHandler<GetProductsQuery, GetProductsResponse>
{

	public async Task<GetProductsResponse> Handle(GetProductsQuery command, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"GetProductsHandler.Handle {command!}");

		var result = await _session.Query<Product>().OrderBy(x => x.Name).ToListAsync();

		var products = result.Adapt<IEnumerable<Product>>();

		return new GetProductsResponse(products);
	}
}
