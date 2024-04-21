using System.Linq.Expressions;

namespace LinkedQueue
{
	 class Program
	{
		static void Main()
		{
			var q = new CustomQueue<int>();
			q.Enqueue(1);
			q.Enqueue(2);
			q.Enqueue(3);
			q.Enqueue(4);
			Console.WriteLine(q.Dequeue());
			Console.WriteLine(q.ToString());
		}

	}
}
