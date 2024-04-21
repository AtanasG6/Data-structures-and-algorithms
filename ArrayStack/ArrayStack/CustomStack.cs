using System.Text;

namespace ArrayStack
{
	public class CustomStack<T>
	{
		private T[] items;
		public int Count { get; private set; }

		private const int INITIAL_CAPACITY = 4;

		public CustomStack(int size = INITIAL_CAPACITY)
		{
			items = new T[size];
			Count = 0;
		}

		public void Push(T element)
		{
			if (items.Length == Count)
			{
				Array.Resize(ref items, Count * 2);
			}

			items[Count++] = element;
		}

		public T Pop()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("The stack is empty.");
			}

			Count--;
			var elementToDelete = items[Count];
			items[Count] = default(T);
			return elementToDelete;
		}

		public T Peek()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("The stack is empty.");
			}

			return items[Count-1];
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			for (int i = 0; i < Count; i++)
			{
				sb.Append(items[i] + " ");
			}
			
			return sb.ToString();
		}
	}
}
