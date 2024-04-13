using Catalog.API.Models;
using Mapster;
using Utilities.CQRS;

namespace Catalog.API.ProductFeatures.CreateProduct;

public record CreateProductCommand(CreateProductDto product) : ICommand<CreateProductResponse>
{
}
public record CreateProductResponse(Guid Id)
{
}

internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // map dto to entity
        // save entity
        // return response

        var product = command.product.Adapt<Product>();

        return new CreateProductResponse(product.Id);
    }
}

