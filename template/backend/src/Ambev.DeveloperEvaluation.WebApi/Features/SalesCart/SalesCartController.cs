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
            catch (Exception ex)
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


            


        }

    }
}
