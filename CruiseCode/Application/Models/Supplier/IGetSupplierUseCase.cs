using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Domain.Entities;


namespace Application.Models.Supplier
{
    public interface IGetSupplierUseCase
    {
        Task<Entities.Supplier> Handle();
    }
}
