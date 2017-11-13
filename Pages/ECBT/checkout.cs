using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Braintree;
using Microsoft.AspNetCore.Http;

namespace razor.Pages
{
    public class checkoutModel : PageModel
    {
        public string ClientToken { get; set; } 
        public void OnGet()
        {
            BraintreeGateway gateway = new BraintreeGateway("access_token$sandbox$jpxq4ty8f49p7b24$908db8de90df4a6c6c969a7822664120");
            ClientToken = gateway.ClientToken.Generate();
        }
    }
}
