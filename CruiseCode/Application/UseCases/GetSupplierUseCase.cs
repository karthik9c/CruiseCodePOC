using Application.Models.Supplier;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class GetSupplierUseCase : IGetSupplierUseCase
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierUseCase(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Supplier> Handle()
        {
            return await _supplierRepository.GetSuppliersync();
        }
    }
}
