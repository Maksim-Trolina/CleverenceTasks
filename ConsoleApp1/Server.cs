using System.Threading;

namespace ConsoleApp1
{
    static internal class Server
    {
        static int count;
        static readonly ReaderWriterLockSlim locker = new();

        public static void AddToCount(int value)
        {
            locker.EnterWriteLock();
            try
            {
                checked
                {
                    count += value;
                }
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
        public static int GetCount()
        {
            locker.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                locker.ExitReadLock();
            }
        }
    }
}
