namespace Catalog.API.Mappings;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<CreateProductDto, CreateProductCommand>()
        //    .Map(dest => dest.product, src => src);

    }
}
