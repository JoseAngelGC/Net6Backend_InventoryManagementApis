using AutoMapper;
using InventoryManagement.Adstractions.Helpers;
using InventoryManagement.Adstractions.UseCasesPorts;
using InventoryManagement.Adstractions.UseCasesPorts.commons;
using InventoryManagement.Adstractions.UseCasesSegregation.Catalogs;
using InventoryManagement.Dtos.Abstractions;
using InventoryManagement.Dtos.Catalogs.Request;
using InventoryManagement.Dtos.Catalogs.Responses;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.ArticlesInventory.Catalogs;
using InventoryManagement.Shared.Utilities.Constants;
using InventoryManagement.Shared.Utilities.ErrorDtos;
using InventoryManagement.UseCases.Catalogs.Validators;

namespace InventoryManagement.UseCases.Catalogs
{
    internal class SupplierCatalogCrudInteractor : ISupplierCatalogUseCaseInputPort<SupplierCatalog>
    {
        private readonly ICatalogQueryOperationsUseCase<SupplierCatalog> _catalogQueryOperationsUseCase;
        private readonly ICatalogCommandOperationsUseCase<SupplierCatalog> _catalogCommandOperationsUseCase;
        private readonly IResponseOutputPort<IResponseResult> _responseOutputPort;
        private readonly IResponseResultHelpers _responseResultHelpers;
        private readonly RequestSupplierByModifyCatalogDtoValidator _requestSupplierByModifyCatalogDtoValidator;
        private readonly RequestSupplierCatalogDtoValidator _requestSupplierCatalogDtoValidator;
        private readonly IMapper _mapper;
        public SupplierCatalogCrudInteractor(ICatalogQueryOperationsUseCase<SupplierCatalog> catalogQueryOperationsUseCase,
            ICatalogCommandOperationsUseCase<SupplierCatalog> catalogCommandOperationsUseCase,
            IResponseOutputPort<IResponseResult> responseOutputPort, IResponseResultHelpers responseResultHelpers, 
            RequestSupplierByModifyCatalogDtoValidator requestSupplierByModifyCatalogDtoValidator, 
            RequestSupplierCatalogDtoValidator requestSupplierCatalogDtoValidator, IMapper mapper)
        {
            _catalogQueryOperationsUseCase = catalogQueryOperationsUseCase;
            _catalogCommandOperationsUseCase = catalogCommandOperationsUseCase;
            _responseOutputPort = responseOutputPort;
            _responseResultHelpers = responseResultHelpers;
            _requestSupplierByModifyCatalogDtoValidator = requestSupplierByModifyCatalogDtoValidator;
            _requestSupplierCatalogDtoValidator = requestSupplierCatalogDtoValidator;
            _mapper = mapper;
            
        }

        #region ShowAllRecords without params
        /// <summary>
        /// Get all supplier catalog records ordered by id and descended way.
        /// </summary>
        /// <returns>The successfully completed task.</returns>
        public async Task<Task> ShowAllRecordsAsync()
        {
            ResponseResult<IEnumerable<SupplierCatalog>> response = new();
            var dataResult = await _catalogQueryOperationsUseCase.AllRecordsOrderedByIdDescAsync();
            _responseResultHelpers.ByPassingValuesAsync(ref response, true, dataResult, dataResult.Count());

            //OutputPort response
            await _responseOutputPort.Handle(_mapper.Map<ResponseResult<IEnumerable<ResponseSupplierCatalogDto>>>(response));
            return Task.CompletedTask;
        }
        #endregion

        #region ShowRecord with id and request params
        /// <summary>
        /// Get one supplier catalog record
        /// </summary>
        /// <param name="id">Appertain to supplier catalog identifier.</param>
        /// <param name="request">Appertain to requestDto object from supplier catalog.</param>
        /// <returns>The successfully completed task.</returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="CustomBadRequestException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<Task> ShowRecordAsync(int id, RequestSupplierCatalogDto request)
        {
            //Request validation
            var validationResult = await _requestSupplierCatalogDtoValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //id param validation
            if (id != request.Id)
                throw new CustomBadRequestException(ReplyMessages.MESSAGE_DISCREPANCY);

            //InputPort(Interactor) Logic
            ResponseResult<SupplierCatalog> response = new();
            var recordResult = await _catalogQueryOperationsUseCase.ItemAsync(id) ?? throw new KeyNotFoundException(ReplyMessages.MESSAGE_NOTFOUND);
            _responseResultHelpers.ByPassingValuesAsync(ref response, true, recordResult, ReplyMessages.MESSAGE_QUERY_SUCCESSFULL);

            //OutputPort response
            await _responseOutputPort.Handle(_mapper.Map<ResponseResult<ResponseSupplierCatalogDto>>(response));
            return Task.CompletedTask;
        }
        #endregion

        #region CreateRecord with request param
        /// <summary>
        /// Create supplier catalog record
        /// </summary>
        /// <param name="request">Appertain to requestDto object from supplier catalog.</param>
        /// <returns>The successfully completed task.</returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="CustomBadRequestException"></exception>
        public async Task<Task> CreateRecordAsync(RequestSupplierCatalogDto request)
        {
            //Request validation
            var validationResult = await _requestSupplierCatalogDtoValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //InputPort(Interactor) Logic
            ResponseResult<int> response = new();
            var existItem = await _catalogQueryOperationsUseCase.ExistsAsync(request.Name);
            if (existItem)
            {
                throw new CustomBadRequestException(ReplyMessages.MESSAGE_EXIST);
            }
            else
            {
                request.Id = 0;
                request.Code = null;
                var entityMapping = _mapper.Map<SupplierCatalog>(request);
                var operationResult = await _catalogCommandOperationsUseCase.CreateAsync(entityMapping, request.UserAlias);
                var message = operationResult > 0 ? ReplyMessages.MESSAGE_SAVE : ReplyMessages.MESSAGE_NOTSAVE;
                _responseResultHelpers.CatalogCommandOperationAsync(ref response, operationResult, message);
            }

            //OutputPort response
            await _responseOutputPort.Handle(response);
            return Task.CompletedTask;
        }
        #endregion

        #region EditRecord with request param
        /// <summary>
        /// Update supplier catalog record
        /// </summary>
        /// <param name="request">Appertain to requestDto object from supplier catalog.</param>
        /// <returns>The successfully completed task.</returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<Task> EditRecordAsync(RequestSupplierByModifyCatalogDto request)
        {
            //Request validation
            var validationResult = await _requestSupplierByModifyCatalogDtoValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //InputPort(Interactor) Logic
            ResponseResult<int> response = new();
            var existItem = await _catalogQueryOperationsUseCase.ExistsAsync(request.Id, request.Code);
            if (!existItem)
            {
                throw new KeyNotFoundException(ReplyMessages.MESSAGE_NOTFOUND);
            }
            else
            {
                var entityMapping = _mapper.Map<SupplierCatalog>(request);
                var operationResult = await _catalogCommandOperationsUseCase.EditAsync(entityMapping, request.UserAlias);
                var message = operationResult > 0 ? ReplyMessages.MESSAGE_UPDATE : ReplyMessages.MESSAGE_NOTUPDATE;
                _responseResultHelpers.CatalogCommandOperationAsync(ref response, operationResult, message);
            }

            //OutputPort response
            await _responseOutputPort.Handle(response);
            return Task.CompletedTask;
        }
        #endregion

        #region DeleteRecord with id and request params
        /// <summary>
        /// Remove supplier catalog record
        /// </summary>
        /// <param name="id">Appertain to supplier catalog record identifier.</param>
        /// <param name="request">Appertain to requestDto object from supplier catalog.</param>
        /// <returns>The successfully completed task.</returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="CustomBadRequestException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<Task> DeleteRecordAsync(int id, RequestSupplierByModifyCatalogDto request)
        {
            //Request validation
            var validationResult = await _requestSupplierByModifyCatalogDtoValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //id param validation
            if (id != request.Id)
                throw new CustomBadRequestException(ReplyMessages.MESSAGE_DISCREPANCY);

            //InputPort(Interactor) Logic
            ResponseResult<int> response = new();
            var getItem = await _catalogQueryOperationsUseCase.ItemAsync(id, (Guid)request.Code!, request.Name);
            if (getItem is null)
            {
                throw new KeyNotFoundException(ReplyMessages.MESSAGE_NOTFOUND);
            }
            else
            {
                var operationResult = await _catalogCommandOperationsUseCase.DeleteAsync(getItem);
                var message = operationResult > 0 ? ReplyMessages.MESSAGE_DELETE : ReplyMessages.MESSAGE_NOTDELETE;
                _responseResultHelpers.CatalogCommandOperationAsync(ref response, operationResult, message);
            }

            //OutputPort response
            await _responseOutputPort.Handle(response);
            return Task.CompletedTask;
        }
        #endregion
    }
}
