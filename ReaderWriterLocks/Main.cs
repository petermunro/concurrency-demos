using System;

public class RunConcurrentHolder
{
	public static void Main(string[] args)
	{
		ConcurrentHolder<int> ch = new  ConcurrentHolder<int>(3);
		printVal(ch);
		ch.SetResource(9);
		printVal(ch);
	}

	private static void printVal(ConcurrentHolder<int> val)
	{
		int res = 0;
		val.GetResource(ref res);
		Console.WriteLine("value is {0}", res);
	}

}

