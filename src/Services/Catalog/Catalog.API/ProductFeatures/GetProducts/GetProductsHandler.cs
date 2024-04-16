using Catalog.API.Models;
using MediatR;
using Utilities.CQRS;

namespace Catalog.API.ProductFeatures.GetProducts;

public record GetProductsQuery : IQuery<GetProductsResponse>;
//public record ProductDto(string Name, string Description, decimal Price,string ImageFile, List<string> Category);
public record GetProductsResponse(IReadOnlyList<Product> Products); // should be a IEnumerable?? 
internal class GetProductsHandler : IQueryHandler<GetProductsQuery, GetProductsResponse>
{

    Task<GetProductsResponse> IRequestHandler<GetProductsQuery, GetProductsResponse>.Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
