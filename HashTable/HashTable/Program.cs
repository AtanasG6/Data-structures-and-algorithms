namespace HashTable
{
	 class Program
	{
		static void Main()
		{
			var hashTable = new HashTable<string, int>();
			hashTable.Add("Ivan", 5);
			hashTable.Add("Dimitar", 6);

			Console.WriteLine(hashTable.ToString());
		}
	}
}
