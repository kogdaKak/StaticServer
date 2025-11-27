using Server.Server;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServerxUnitTests
{
    public class LoadTest
    {
        public LoadTest()
        {
            LockServer.ResetForTest();
        }

        [Fact]
        public async Task FinalCount()
        {
            int writersCount = 100;
            int readersCount = 5000;
            int increment = 1;

            var writes = Enumerable.Range(0, writersCount).Select(writer => Task.Run(() => 
            { 
                LockServer.AddToCount(increment); 
            }
            )).ToArray();

            var readers = Enumerable.Range(0, readersCount).Select(reader => Task.Run(() => 
            { 
                LockServer.GetCount(); 
            }
            )).ToArray();

            await Task.WhenAll(writes.Concat(readers).ToArray());

            int expected = writersCount * increment;
            int actual = LockServer.GetCount();

            Assert.Equal(expected, actual);
        }
    }
}
