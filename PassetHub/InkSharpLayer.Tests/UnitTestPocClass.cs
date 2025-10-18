using InkSharp;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json.Linq;
using PassetHub.NetApi.Generated.Model.frame_system;
using PassetHub.NetApi.Generated.Model.pallet_revive.storage;
using Substrate.NetApi;
using Xunit.Abstractions;

namespace InkSharpLayer.Tests
{
    public class UnitTestPocClass
    {

        private readonly ITestOutputHelper _output;

        public UnitTestPocClass(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public async Task TestPassetHubRpcOk()
        {
            PassetHub.NetApi.Generated.Model.frame_system.AccountInfo result = await PoC.SamplePassetHubRpcCall();

            _output.WriteLine(result.ToString());
        }

        [Fact]
        public async Task TestDaoContractInfoQueryOk()
        {
            string contractAddress = "0xda30aa6Ba225E8245746b8Adbca489872F037708";
            PassetHub.NetApi.Generated.Model.pallet_revive.storage.AccountInfo result = await PoC.QueryContractStorage_AccountInfoAtAddress(contractAddress);

            Assert.NotNull(result); // call successfull

            Assert.Equal(expected: AccountType.Contract, result.AccountType.Value);
            var contractInfo = result.AccountType.Value2 as ContractInfo;

            _output.WriteLine(contractInfo.TrieId.ToString());
        }

        [Fact]  
        public async Task TestDecodeOfResponse()
        {
            PassetHub.NetApi.Generated.Model.pallet_revive.storage.AccountInfo info = new PassetHub.NetApi.Generated.Model.pallet_revive.storage.AccountInfo();
            info.Create("0x735f040a5d490f1107ad9c56f5ca00d2ae37ff0591fdbbcd9c2406df7147a9dc170eab77a1911b43ce5b9e09fd610861026ad42e");

            _output.WriteLine(info.ToString());
        }
    }
}
