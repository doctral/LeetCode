namespace Data_Structure_Implementation.BinaryTree
{
	public class BinaryTreeNode
	{
		private int val;
		private BinaryTreeNode left, right;
		public BinaryTreeNode()
		{
			this.val = 0;
		}
		public BinaryTreeNode(int val)
		{
			this.val = val;
		}

		public int Value {
			get { return this.val; }
			set { this.val = value; }
		}

		public BinaryTreeNode Left {
			get => this.left;
			set => this.left = value;
		}

		public BinaryTreeNode Right {
			get => this.right;
			set => this.right = value;
		}
	}
}
