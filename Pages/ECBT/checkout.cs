using Microsoft.AspNetCore.Mvc.RazorPages;
using Braintree;

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
