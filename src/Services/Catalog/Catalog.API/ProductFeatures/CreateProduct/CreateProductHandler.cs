namespace Catalog.API.Products.CreateProduct;
public record CreateProductCommand(ProductDto product)
	: ICommand<Product>
{ }

internal class CreateProductCommandHandler
	(IDocumentSession session)
	: ICommandHandler<CreateProductCommand, Product>
{
	public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
		var product = command.product.Adapt<Product>();

		session.Store(product);
		await session.SaveChangesAsync(cancellationToken);

		return product;

	}
}