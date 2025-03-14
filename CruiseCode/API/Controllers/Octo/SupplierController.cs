using Application.Models.Supplier;
using Domain.Entities;
using Infrastructure.APIStandard.Mapper.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OctoEntities = Infrastructure.APIStandard.Models.Octo;


namespace API.Controllers.Octo
{
    [Route("api/octo/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly IGetSupplierUseCase _getSupplierUseCase;
        private readonly ISupplierMappingStrategy<OctoEntities.Supplier> _mappingStrategy;

        public SupplierController(IGetSupplierUseCase getSupplierUseCase, ISupplierMappingStrategy<OctoEntities.Supplier> mappingStrategy)
        {
            _getSupplierUseCase = getSupplierUseCase;
            _mappingStrategy = mappingStrategy;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var suppliers = await _getSupplierUseCase.Handle();
            var octoSupplier = _mappingStrategy.Map(suppliers);
            return Ok(octoSupplier);
        }
    }
}
