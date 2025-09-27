using System;
using System.Security.Cryptography;
using PassetHub.NetApi.Generated.Types.Base;


namespace InkSharp;


public class TestClass
{
    public async Task TestCall()
    {
        var token = CancellationToken.None;

        // var substrateClient = new PassetHub.NetApi.Generated.SubstrateClientExt("wss://passet-hub-paseo.ibp.network", Charge);

        // Example Substrate address
        var substrateAddress = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY";

        // Parameter of the query
        var account = new PassetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32();
        // account.Create(Utils.substrateAddress);

        // Query chain state
        var result = await substrateClient.SystemStorage.Account(
            account,
            null,
            token
        );
    }
}
