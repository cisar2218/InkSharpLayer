using PassetHub.NetApi.Generated.Model.frame_system;
using PassetHub.NetApi.Generated.Model.pallet_revive.storage;
using PassetHub.NetApi.Generated.Model.primitive_types;
using PassetHub.NetApi.Generated.Model.sp_core.crypto;
using PassetHub.NetApi.Generated.Types.Base;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;


namespace InkSharp;


public class PoC
{
    public static async Task<PassetHub.NetApi.Generated.Model.frame_system.AccountInfo> SamplePassetHubRpcCall()
    {
        var token = CancellationToken.None;

        var substrateClient = new PassetHub.NetApi.Generated.SubstrateClientExt(new Uri("wss://passet-hub-paseo.dotters.network"), ChargeTransactionPayment.Default());
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

    public static async Task<PassetHub.NetApi.Generated.Model.pallet_revive.storage.AccountInfo> QueryContractStorage_AccountInfoAtAddress(string contractAddress)
    {
        var token = CancellationToken.None;

        var substrateClient = new PassetHub.NetApi.Generated.SubstrateClientExt(new Uri("wss://passet-hub-paseo.dotters.network"), ChargeTransactionPayment.Default());
        await substrateClient.ConnectAsync();

        H160 contract = new H160();
        
        contract.Create(contractAddress);

        Debug.Assert(contract.Bytes.Length == 20, "Contract address probably wrong format.");
        
        // Query chain state
        var result = await substrateClient.ReviveStorage.AccountInfoOf(
            contract,
            null,
            token
        );

        return result;
    }

    public static async Task<bool> ReadFlipperValueFromState(H160 contractAddress)
    {
        using var client = new PassetHub.NetApi.Generated.SubstrateClientExt(
            new Uri("wss://passet-hub-paseo.dotters.network"),
            ChargeTransactionPayment.Default());

        await client.ConnectAsync();
        var token = CancellationToken.None;

        var accountInfo = await client.ReviveStorage.AccountInfoOf(contractAddress, null, token);

        if (accountInfo == null || accountInfo.AccountType.Value != AccountType.Contract)
                throw new Exception("Not a contract or no AccountInfo found");

        var contractInfo = accountInfo?.AccountType.Value2 as ContractInfo;
        var trieId = contractInfo?.TrieId.Value.Value; // byte[33]

        // TODO

        return false;
    }
}
