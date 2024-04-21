namespace Tree
{
	public class Tree<T>
	{
		public TreeNode<T> Root { get; private set; }

		public Tree(T value, params Tree<T>[] subtrees)
		{
			Root = new TreeNode<T>(value);
			foreach (var subtree in subtrees)
			{
				Root.Children.Add(subtree.Root);
			}
		}

		public void DFSRecursive()
		{
			DFSRecursive(Root);
		}

		private void DFSRecursive(TreeNode<T> root)
		{
			Console.WriteLine(root.Value);
			foreach (var child in root.Children)
			{
				DFSRecursive(child);
			}
		}

		public void TraverseDFS()
		{
			var stack = new Stack<TreeNode<T>>();
			stack.Push(Root);

			while (stack.Count > 0)
			{
				var currentNode = stack.Pop();
				Console.WriteLine(currentNode.Value);

				foreach (var child in currentNode.Children)
				{
					stack.Push(child); 
				}
			}
		}

		public void TraverseBFS()
		{
			var q = new Queue<TreeNode<T>>();
			q.Enqueue(Root);

			while (q.Count > 0)
			{
				var currentNode = q.Dequeue();
				Console.WriteLine(currentNode.Value);

				foreach (var child in currentNode.Children)
				{
					q.Enqueue(child);
				}
			}
		}
	}
}
