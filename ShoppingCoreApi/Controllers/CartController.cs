using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCoreApi.Services;
using ShoppingCoreApi.Services.ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<ActionResult> PostCartItem([FromBody] List<string> itemNames)
        {
            ServiceResponse<string> result = await _service.CreateCartItems(itemNames);

            return result.FormatResponse();
        }

        [HttpDelete("delete/{shoppingCode}")]
        public async Task<ActionResult> DeleteCartItem([FromRoute] string shoppingCode)
        {
            ServiceResponse<string> result = await _service.DeleteCartItems(shoppingCode);

            return result.FormatResponse();
        }

        [HttpGet("amount/{shoppingCode}")]
        public async Task<ActionResult> GetCartItemsAmount([FromRoute] string shoppingCode)
        {
            ServiceResponse<string> result = await _service.GetItemsTotalAmount(shoppingCode);

            return result.FormatResponse();
        }

    }
}
