namespace Catalog.API.ProductFeatures.UpdateProduct;

public record UpdateProductCommand(Product Product) : ICommand;

internal class UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> _logger, IDocumentSession _session) : ICommandHandler<UpdateProductCommand, Unit>
{
	public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"UpdateProductCommandHandler.Handle {request!}");

		_session.Store(request.Product);
		await _session.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}
