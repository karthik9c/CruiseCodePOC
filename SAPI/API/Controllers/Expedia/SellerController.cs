using Application.Models.Supplier;
using Domain.Entities;
using Infrastructure.APIStandard.Mapper.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpediaEntities = Infrastructure.APIStandard.Models.Expedia;

namespace API.Controllers.Expedia
{
    [Route("api/expedia/[controller]")]
    [ApiController]
    [Authorize]
    public class SellerController : ControllerBase
    {
        private readonly IGetSupplierUseCase _getSupplierUseCase;
        private readonly ISupplierMappingStrategy<ExpediaEntities.Seller> _mappingStrategy;

        public SellerController(IGetSupplierUseCase getSupplierUseCase, ISupplierMappingStrategy<ExpediaEntities.Seller> mappingStrategy)
        {
            _getSupplierUseCase = getSupplierUseCase;
            _mappingStrategy = mappingStrategy;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var supplier = await _getSupplierUseCase.Handle();
            var expediaSeller = _mappingStrategy.Map(supplier);
            return Ok(expediaSeller);
        }
    }
}
