using System;
using System.Security.Cryptography;
using PassetHub.NetApi.Generated.Model.frame_system;
using PassetHub.NetApi.Generated.Types.Base;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;


namespace InkSharp;


public class PoC
{
    public static async Task<AccountInfo> SamplePassetHubRpcCall()
    {
        var token = CancellationToken.None;

        var substrateClient = new PassetHub.NetApi.Generated.SubstrateClientExt(new Uri("wss://asset-hub-paseo.dotters.network"), ChargeTransactionPayment.Default());
        await substrateClient.ConnectAsync(); 

        // Example Substrate address
        var substrateAddress = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY";

        // Parameter of the query
        var account = new PassetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32();
        account.Create(Utils.GetPublicKeyFrom(substrateAddress));

        // Query chain state
        var result = await substrateClient.SystemStorage.Account(
            account,
            null,
            token
        );

        return result;
    }
}
