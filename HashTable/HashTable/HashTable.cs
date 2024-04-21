using System.Text;

namespace HashTable
{
	public struct HashEntry<K, V>
	{
		public K Key { get; set; }
		public V Value { get; set; }
	}

	public class HashTable<K, V>
	{
		private readonly int size;
		private const int INITIAL_CAPACITY = 64;
		private readonly LinkedList<HashEntry<K, V>>[] items;

		public HashTable(int size = INITIAL_CAPACITY)
		{
			this.size = size;
			items = new LinkedList<HashEntry<K, V>>[size];
		}

		private int Hash(K key)
		{
			return Math.Abs(key.GetHashCode() % size);
		}

		private LinkedList<HashEntry<K, V>> GetLinkedList(int position)
		{
			var linkedList = items[position];

			if (linkedList == null)
			{
				linkedList = new LinkedList<HashEntry<K, V>>();
				items[position] = linkedList;
			}

			return linkedList;	
		}

		public void Add(K key, V value)
		{
			int position = Hash(key);
			var linkedList = GetLinkedList(position);
			var item = new HashEntry<K, V>() {Key = key, Value = value};
			linkedList.AddLast(item);
		}

		public void Remove(K key)
		{
			int position = Hash(key);
			var linkedList = GetLinkedList(position);
			bool itemFound = false;
			var foundItem = default(HashEntry<K, V>);
			foreach (var item in linkedList)
			{
				if (item.Key.Equals(key))
				{
					itemFound = true;
					foundItem = item;
				}
			}

			if (itemFound)
			{
				linkedList.Remove(foundItem);
			}
		}

		public V Find(K key)
		{
			int position = Hash(key);
			var linkedList = GetLinkedList(position);
			foreach (var item in linkedList)
			{
				if (item.Key.Equals(key))
				{
					return item.Value;
				}
			}

			return default(V);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var linkedList in items)
			{
				if (linkedList != null)
				{
					foreach (var hashEntry in linkedList)
					{
						sb.Append(hashEntry.Key);
						sb.Append(" ");
						sb.Append(hashEntry.Value);
						sb.Append("\n");
					}
				}
			}
			return sb.ToString();
		}

	}
}
