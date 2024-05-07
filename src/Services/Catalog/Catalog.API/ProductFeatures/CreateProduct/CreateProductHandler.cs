using Catalog.API.Dtos;

namespace Catalog.API.Products.CreateProduct;
public record CreateProductCommand(ProductDto product)
	: ICommand<Product>
{ }

internal class CreateProductCommandHandler
	(IDocumentSession session, ILogger<CreateProductCommandHandler> _logger)
	: ICommandHandler<CreateProductCommand, Product>
{
	public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
		_logger.LogInformation("CreateProductCommandHandler.handle called with {@command} ", command);
		var product = command.product.Adapt<Product>();

		session.Store(product);
		await session.SaveChangesAsync(cancellationToken);

		return product;

	}
}