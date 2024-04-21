namespace ArrayStack
{
	 class Program
	{
		static void Main()
		{
			CustomStack<int> stack = new CustomStack<int>(2);
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);
			stack.Push(4);
			stack.Push(5);
			Console.WriteLine(stack.Pop());
			Console.WriteLine(stack.Peek());
			Console.WriteLine(stack.ToString());
			
		}
	}
}
