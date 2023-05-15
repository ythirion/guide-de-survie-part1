using System.Threading.Tasks;
using Xunit;

namespace Approval.Tests.Integration
{
    public class PartiesControllerTests : IntegrationTests
    {
        public PartiesControllerTests(AppFactory appFactory) : base(appFactory)
        {
        }

        [Fact]
        public async Task Should_Retrieve_Capone_And_Mesrine_With_Verify()
            => await Client.GetAsync("/parties")
                .Verify(settings => settings.DontScrubDateTimes());
    }
}