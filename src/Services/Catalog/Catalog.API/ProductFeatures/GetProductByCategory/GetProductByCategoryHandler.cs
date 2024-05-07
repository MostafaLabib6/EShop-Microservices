
namespace Catalog.API.ProductFeatures.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResponse>;

public record GetProductByCategoryResponse(IEnumerable<ProductDto> Products);

internal class GetProductByCategoryQueryHandler
	(ILogger<GetProductByCategoryQueryHandler> _logger, IDocumentSession _seesion)
		: IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResponse>
{
	public async Task<GetProductByCategoryResponse> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"GetProductByCategoryQueryHandler.Handle {query!}");

		var products = await _seesion.Query<Product>()
			.Where(p => p.Category.Contains(query.Category))
			.ToListAsync(cancellationToken);

		return new GetProductByCategoryResponse(products.Adapt<IEnumerable<ProductDto>>());
	}
}
