using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Braintree;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        // POST api/transaction
        [HttpPost]
        public void Post(IFormCollection collection)
        {
            BraintreeGateway gateway = new BraintreeGateway("access_token$sandbox$jpxq4ty8f49p7b24$908db8de90df4a6c6c969a7822664120");

            TransactionRequest request = new TransactionRequest
            {
                Amount = 1000.0M,
                MerchantAccountId = "USD",
                PaymentMethodNonce = collection["payment_method_nonce"],
                ShippingAddress = new AddressRequest
                {
                    FirstName = "Jen",
                    LastName = "Smith",
                    Company = "Braintree",
                    StreetAddress = "1 E 1st St",
                    ExtendedAddress = "Suite 403",
                    Locality = "Bartlett",
                    Region = "IL",
                    PostalCode = "60103",
                    CountryCodeAlpha2 = "US"
                },
                Options = new TransactionOptionsRequest
                {
                    PayPal = new TransactionOptionsPayPalRequest
                    {
                        CustomField = "PayPal custom field",
                        Description = "Description for PayPal email receipt",
                    },
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            Transaction transaction = result.Target;

            if (result.IsSuccess())
            {
                Response.WriteAsync("Transaction ID: " + transaction.PayPalDetails.AuthorizationId);
            }
            else
            {
                Response.WriteAsync("Error Message:" + result.Message);
            }
        }

        // // GET api/values
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get([FromQuery]int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody]string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }

    }
}
