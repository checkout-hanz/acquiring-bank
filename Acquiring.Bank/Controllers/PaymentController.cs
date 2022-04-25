using Acquiring.Bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace Payment.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        // This is just a mock acquiring bank api which will returns if a transaction is success or fail
        // if provider is not correct then it will return failed response
        // if amount is ? 100 then it will also return failed response

        [HttpPost]
        [ProducesResponseType(typeof(PaymentTransactionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PaymentTransactionResponse), StatusCodes.Status400BadRequest)]
        public IActionResult Create(PaymentTransactionRequest request)
        {
            var transactionResponse = new PaymentTransactionResponse()
            {
                TransactionId = request.TransactionId.ToString()
            };

            if (request.ProviderId != "checkout.com" || request.Amount > 100)
            {
                transactionResponse.Status = PaymentTransactionStatus.Failed;
                return BadRequest(transactionResponse);
            }

            transactionResponse.Status = PaymentTransactionStatus.Success;
            return Ok(transactionResponse);
        }
    }
}