using Server.Interfaces;
using Server.Logic;

namespace Server.Server
{
    public static class LockServer
    {
        private static readonly ICounter _counter = new ReaderWriterCount();
        public static int GetCount() => _counter.GetCount();
        public static void AddToCount(int value) => _counter.AddToCount(value);

        public static void ResetForTest()
        {
            if (_counter is ReaderWriterCount impl)
                impl.Reset();
        }
    }
}
