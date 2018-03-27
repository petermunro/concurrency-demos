using System.Threading;

public partial class ConcurrentHolder<T>
{
	private const int timeout = 100;
	private T theResource;
	private int uses;
	private ReaderWriterLockSlim theLock = new ReaderWriterLockSlim();

	public ConcurrentHolder(T resource)
	{
		theResource = resource;
	}

	public void SetResource(T newResource)
	{
		theLock.EnterWriteLock();
		try {
			theResource = newResource;
			Interlocked.Increment(ref uses);
		}
		finally
		{
			theLock.ExitWriteLock();
		}
	}

	public void GetResource(ref T destination)
	{
		theLock.EnterReadLock();
		try {
			destination = theResource;
			Interlocked.Increment(ref uses);
		}
		finally
		{
			theLock.ExitReadLock();
		}
	}
}

