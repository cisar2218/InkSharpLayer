using InkSharp;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using PassetHub.NetApi.Generated.Model.frame_system;
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
            AccountInfo result = await PoC.SamplePassetHubRpcCall();

            _output.WriteLine(result.ToString());
        }
    }
}
