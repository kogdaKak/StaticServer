using Server.Server;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServerxUnitTests
{
    public class NonFuncTest
    {
        [Fact]
        public async Task FinishTime()
        {
            LockServer.ResetForTest();

            for (int i = 0; i < 1000; i++)
            {
                LockServer.AddToCount(1);
            }

            int readersCount = 5000;

            var sw = Stopwatch.StartNew();

            var readers = Enumerable.Range(0, readersCount).Select(reader => Task.Run(() => 
            { 
                int value = LockServer.GetCount(); 
                return value; }
            )).ToArray();

            await Task.WhenAll(readers);

            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 2000, $"Долго");
        }
    }
}
