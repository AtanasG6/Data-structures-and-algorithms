namespace Tree
{
	class Program
	{
		static void Main()
		{
			var tree = new Tree<int>(1, 
				          new Tree<int>(2, 
					          new Tree<int>(5, 
						          new Tree<int>(6))),
				                        new Tree<int>(3, 
					                        new Tree<int>(4)));
			//tree.DFSRecursive();
			//tree.TraverseDFS();
			tree.TraverseBFS();
		}
	}
}
