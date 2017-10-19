using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Braintree;

public class BraintreeOps
{
    static public string GetClientToken()
    {
        BraintreeGateway gateway = new BraintreeGateway("access_token$sandbox$jpxq4ty8f49p7b24$908db8de90df4a6c6c969a7822664120");
        var clientToken = gateway.ClientToken.Generate();
        return clientToken;
    }
}
