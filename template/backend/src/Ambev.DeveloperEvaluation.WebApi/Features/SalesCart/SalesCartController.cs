using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart.Results;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart;
using Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart.Results;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.ModifySalesCart;
using Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart;
using Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart.Results;
using Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.GetSalesCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CancelSalesCart;
using Ambev.DeveloperEvaluation.Application.SalesCart.CancelSalesCart;
using Ambev.DeveloperEvaluation.Application.SalesCart.CancelSalesCart.Results;
using System.Threading;
using System.Net;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart
{
    /// <summary>
    /// Controller for managing sales cart operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SalesCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public SalesCartController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }


        /// <summary>
        /// Creates a new sales cart
        /// </summary>
        /// <param name="request">Sales cart creation data</param>
        /// <returns>Created sales cart with calculated prices and discounts</returns>
        /// <response code="201">Sales cart created successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="404">Customer, branch or product not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesCartResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponseWithData<CreateSalesCartResult>>> CreateSalesCart(
            [FromBody] CreateSalesCartRequest request)
        {

            try
            {

                var validator = new CreateSalesCartRequestValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var command = _mapper.Map<CreateSalesCartCommand>(request);

                // Send command through mediator
                var result = await _mediator.Send(command);

                return Created(string.Empty,
                    new ApiResponseWithData<CreateSalesCartResult>
                    {
                        Success = true,
                        Message = "Sales cart created successfully.",
                        Data = result,
                    }
                );

            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
            }
            catch
            {
                return StatusCode(500, new ApiResponse
                {
                    Message = "An unexpected error occurred",
                    Success = false,
                });
            }

        }

        /// <summary>
        /// Modifys a sales cart
        /// </summary>
        /// <param name="request">Sales cart modified data</param>
        /// <returns>Modify sales cart with calculated prices and discounts</returns>
        /// <response code="201">Sales cart modified successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="404">Sales Cart, customer, branch or product not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseWithData<ModifySalesCartResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponseWithData<CreateSalesCartResult>>> ModifySalesCart(
            [FromBody] ModifySalesCartRequest request)
        {
            try
            {

                var validator = new ModifySalesCartRequestValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var command = _mapper.Map<ModifySalesCartCommand>(request);
                var result = await _mediator.Send(command);

                return Created(string.Empty,
                    new ApiResponseWithData<ModifySalesCartResult>
                    {
                        Success = true,
                        Message = "Sales cart modified successfully.",
                        Data = result,
                    }
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
            }
            catch
            {
                return StatusCode(500, new ApiResponse
                {
                    Message = "An unexpected error occurred",
                    Success = false,
                });
            }
        }
        /// <summary>
        /// Get a Sale Cart
        /// </summary>
        /// <param name="salesCartId">SalesCart Id</param>
        /// <returns>SalesCart Data</returns>
        /// <response code="200">Sales Cart Data</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="404">Sales Cart, customer, branch or product not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<ModifySalesCartResult>), StatusCodes.Status200OK)]        
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponseWithData<GetSalesCartResult>>> GetSalesCart(
            [FromRoute] Guid id)
        {
            try
            {
                var getRequest = new GetSalesCartRequest { SalesCartId = id };

                var validator = new GetSalesCartRequestValidator();
                var validationResult = await validator.ValidateAsync(getRequest);
                
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var command = _mapper.Map<GetSalesCartCommand>(getRequest);
                var result = await _mediator.Send(command);

                return Ok(new ApiResponseWithData<GetSalesCartResult>
                {
                    Success = true,
                    Message = "SalesCart retrieved successfully",
                    Data = result
                });               
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
            }
            catch
            {
                return StatusCode(500, new ApiResponse
                {
                    Message = "An unexpected error occurred",
                    Success = false,
                });
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<ModifySalesCartResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponseWithData<GetSalesCartResult>>> CancelSalesCart(
            [FromRoute] Guid id)
        {
            try
            {
                var cancelRequest = new CancelSalesCartRequest { SalesCartId = id };

                var validator = new CancelSalesCartValidator();
                var validationResult = await validator.ValidateAsync(cancelRequest);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var command = _mapper.Map<CancelSalesCartCommand>(cancelRequest);
                var result = await _mediator.Send(command);

                return Ok(new ApiResponseWithData<CancelSalesCartResult>
                {
                    Success = true,
                    Message = "SalesCart canceled!",
                    Data = result
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
            }
            catch
            {
                return StatusCode(500, new ApiResponse
                {
                    Message = "An unexpected error occurred",
                    Success = false,
                });
            }

        }
    }
}
