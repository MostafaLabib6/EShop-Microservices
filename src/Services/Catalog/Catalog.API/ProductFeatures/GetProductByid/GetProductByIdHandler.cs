namespace Catalog.API.ProductFeatures.GetProductByid;

public record GetProductByIdResponse(ProductDto product);
public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResponse>;

public class GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> _logger, IDocumentSession _session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
{
	public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"GetProductByIdQueryHandler.Handle {query!}");

		var product = await _session.LoadAsync<Product>(query.Id, cancellationToken);

		if (product is null)
			throw new KeyNotFoundException($"Product {query.Id} not found");

		return new GetProductByIdResponse(product.Adapt<ProductDto>());
	}
}
