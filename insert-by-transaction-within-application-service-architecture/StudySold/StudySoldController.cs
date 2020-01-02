using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TodoApi.Service;

namespace TodoApi.StudySold
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudySoldController : ControllerBase
    {
        [HttpGet("index")]
        public string Index()
        {
            return "This is Study Sold.";
        }

        [HttpPost("{id?}")]
        public string Hello()
        {
            return "This is Study Sold Hello.";
        }

        /// <summary>
        ///     Record sell sth
        /// </summary>
        /// <param name="goodId">ID of goods</param>
        /// <param name="quantity">Quantity of Sold Goods</param>
        /// <param name="buyer">Buyer ID</param>
        /// <returns>string</returns>
        [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Successful operation")]
        [HttpPost("sell")]
        public string Sell(int goodId, int quantity, int buyer)
        {
            var sellGoodsTransactionService = new SellGoodsTransactionService();
            return sellGoodsTransactionService.SellGoodsToSbOfService(goodId, quantity, buyer);
        }
    }
}