using Business.Helpers;

namespace Contacts.ConsoleApp.Tests.Helpers
{

    public class IdGenerator_Tests
    {
        [Fact]
        public void Generate_ShouldReturnGuidAsString()
        {
            var result = IdGenerator.Generate();

            Assert.NotNull(result);
            Assert.True(Guid.TryParse(result, out _));
        }
    }
}

