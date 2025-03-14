using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    class SupplierRepository : ISupplierRepository
    {
        public SupplierRepository() { }
        public async Task<Domain.Entities.Supplier> GetSuppliersync()
        {
            // Simulate async database call
            await Task.Delay(1000);
            return new Domain.Entities.Supplier
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Sample Supplier",
                Endpoint = "https://sample-supplier.com",
                Contact = new Domain.Entities.Contact()
                {
                    Address = "123 Sample Street",
                    Telephone = "123-456-7890",
                    Email = "bob@gmail.com",
                    Website = "https://sample-supplier.com"
                }
            };
        }
    }
}
