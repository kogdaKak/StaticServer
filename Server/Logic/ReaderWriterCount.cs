using Server.Interfaces;
using System.Threading;

namespace Server.Logic
{
    public class ReaderWriterCount : ICounter
    {
        private int _count;
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        public int GetCount()
        {
            _lock.EnterReadLock();
            try
            {
                return _count;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void AddToCount(int value)
        {
            _lock.EnterWriteLock();
            try
            {
                checked
                {
                    _count += value;
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Reset()
        {
            _lock.EnterWriteLock();
            try
            {
                _count = 0;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
