using System.Text;

namespace LinkedQueue
{
	class CustomQueue<T>
	{
		public int Count { get; private set; }

		public QueueNode<T> Head { get; set; }

		public QueueNode<T> Tail { get; set; }

		public void Enqueue(T element)
		{
			var node = new QueueNode<T>(element);
			if (Count == 0)
			{
				Head = Tail = node;
			}
			else
			{
				Tail.Next = node;
				node.Prev = Tail;
				Tail = node;
			}

			Count++;
		}

		public T Dequeue()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("The queue is empty.");
			}
			else
			{
				var removedElement = Head.Value;
				Head = Head.Next;

				Count--;
				return removedElement;
			}
			
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			var element = Head;
			while (element != null)
			{
				sb.Append(element.Value + " ");
				element = element.Next;
			}

			return sb.ToString();
		}
	}
}
