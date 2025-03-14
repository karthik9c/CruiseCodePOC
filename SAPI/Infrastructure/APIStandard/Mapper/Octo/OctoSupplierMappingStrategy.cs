using Domain.Entities;
using Infrastructure.APIStandard.Mapper.Interface;
using OctoEntities = Infrastructure.APIStandard.Models.Octo;

namespace Infrastructure.APIStandard.Mapper.Octo
{
    public class OctoSupplierMappingStrategy : ISupplierMappingStrategy<OctoEntities.Supplier>
    {
        public OctoEntities.Supplier Map(Supplier supplier)
        {
            return new OctoEntities.Supplier()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Endpoint = supplier.Endpoint,
                Contact = new OctoEntities.Contact
                {
                    Address = supplier.Contact.Address,
                    Telephone = supplier.Contact.Telephone,
                    Website = supplier.Contact.Website,
                    Email = supplier.Contact.Email
                }
            };
        }
    }
}
