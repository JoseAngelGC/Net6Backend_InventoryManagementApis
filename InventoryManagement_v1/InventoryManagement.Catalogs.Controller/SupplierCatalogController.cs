using InventoryManagement.Adstractions.UseCasesPorts.commons;
using InventoryManagement.Adstractions.UseCasesPorts;
using InventoryManagement.Dtos.Abstractions;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using InventoryManagement.Dtos.Catalogs.Request;

namespace InventoryManagement.Catalogs.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Description("[SupplierCatalog EndPoints]")]
    public class SupplierCatalogController : ControllerBase
    {
        private readonly ISupplierCatalogUseCaseInputPort<SupplierCatalog> _catalogUseCaseInputPort;
        private readonly IResponseOutputPort<IResponseResult> _responseOutputPort;
        public SupplierCatalogController(ISupplierCatalogUseCaseInputPort<SupplierCatalog> catalogUseCaseInputPort, IResponseOutputPort<IResponseResult> responseOutputPort)
        {
            _catalogUseCaseInputPort = catalogUseCaseInputPort;
            _responseOutputPort = responseOutputPort;
        }

        [HttpGet("items")]
        public async Task<ActionResult<IResponseResult>> GetCategoryItemsAsync()
        {
            await _catalogUseCaseInputPort.ShowAllRecordsAsync();
            return Ok(_responseOutputPort.Content);
        }

        [HttpPost("item/{id:int}")]
        public async Task<ActionResult<IResponseResult>> GetCurrencyItemAsync(int id, [FromBody] RequestSupplierCatalogDto request)
        {
            await _catalogUseCaseInputPort.ShowRecordAsync(id, request);
            return Ok(_responseOutputPort.Content);
        }

        [HttpPost("newItem")]
        public async Task<ActionResult<IResponseResult>> CreateCurrencyAsync([FromBody] RequestSupplierCatalogDto request)
        {
            await _catalogUseCaseInputPort.CreateRecordAsync(request);
            return Created("", _responseOutputPort.Content);
        }

        [HttpPut("modifyItem")]
        public async Task<ActionResult<IResponseResult>> EditCurrencyAsync([FromBody] RequestSupplierByModifyCatalogDto request)
        {
            await _catalogUseCaseInputPort.EditRecordAsync(request);
            return Ok(_responseOutputPort.Content);
        }

        [HttpDelete("clearOffItem/{id:int}")]
        public async Task<ActionResult<IResponseResult>> DeleteCurrencyAsync(int id, [FromBody] RequestSupplierByModifyCatalogDto request)
        {
            await _catalogUseCaseInputPort.DeleteRecordAsync(id, request);
            return Ok(_responseOutputPort.Content);
        }
    }
}
