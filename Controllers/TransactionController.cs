using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                PaymentMethodNonce = Request.Form["payment_method_nonce"],
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
                Response.WriteAsync("Transaction ID: " + transaction.Id);
            }
            else
            {
                Response.WriteAsync(result.Message);
            }
        }
    }
}
