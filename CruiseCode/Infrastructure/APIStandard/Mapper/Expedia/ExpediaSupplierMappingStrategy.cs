using Infrastructure.APIStandard.Mapper.Interface;
using ExpediaEntities = Infrastructure.APIStandard.Models.Expedia;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.APIStandard.Mapper.Expedia
{
    class ExpediaSupplierMappingStrategy : ISupplierMappingStrategy<ExpediaEntities.Seller>
    {
        public ExpediaEntities.Seller Map(Supplier supplier)
        {
            return new ExpediaEntities.Seller()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Endpoint = supplier.Endpoint,
                Contact = new ExpediaEntities.Contact()
                {
                    Address = supplier.Contact.Address,
                    Mobile = supplier.Contact.Telephone,
                    Website = supplier.Contact.Website,
                    Email = supplier.Contact.Email
                }
            };
            
        }
    }
}
