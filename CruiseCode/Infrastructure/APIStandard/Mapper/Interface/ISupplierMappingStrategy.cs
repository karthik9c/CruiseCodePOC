using Domain.Entities;

namespace Infrastructure.APIStandard.Mapper.Interface
{
    public interface ISupplierMappingStrategy<TDto>
    {
        TDto Map(Supplier supplier);
    }
}
