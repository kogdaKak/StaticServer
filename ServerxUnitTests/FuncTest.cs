using Server.Server;
using Xunit;

namespace ServerxUnitTests
{
    public class FuncTest
    {
        public FuncTest()
        {
            LockServer.ResetForTest();
        }

        [Fact]
        public void InitialCount()
        {
            int value = LockServer.GetCount();
            Assert.Equal(0, value);
        }

        [Fact]
        public void AddTocount()
        {
            LockServer.ResetForTest();
            LockServer.AddToCount(10);
            LockServer.AddToCount(5);

            int value = LockServer.GetCount();
            Assert.Equal(15, value);
        }
    }
}
