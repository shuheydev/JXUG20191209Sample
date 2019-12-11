using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using XamarinFormsUiPractice;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var uri = await AvatarProvider.GetAvatarUri();

            uri.Should().NotBeNullOrEmpty();
        }
    }
}
