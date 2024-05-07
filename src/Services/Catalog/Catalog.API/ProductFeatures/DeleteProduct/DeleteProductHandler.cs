namespace Catalog.API.ProductFeatures.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand;

internal class DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> _logger, IDocumentSession _session)
	: ICommandHandler<DeleteProductCommand, Unit>
{
	public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"DeleteProductCommandHandler.Handle {command!}");

		_session.DeleteWhere<Product>(x => x.Id == command.Id);

		await _session.SaveChangesAsync();

		return Unit.Value;
	}
}
