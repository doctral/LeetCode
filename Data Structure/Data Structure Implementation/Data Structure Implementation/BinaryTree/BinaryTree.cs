using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure_Implementation.BinaryTree
{
	public class BinaryTree
	{
		private BinaryTreeNode root;

		public BinaryTree()
		{
			root = null;
		}

		public BinaryTree(IList<int?> list)
		{
			root = new BinaryTreeNode(list[0].Value);
			Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();
			Queue<int> indices = new Queue<int>();
			nodes.Enqueue(root);
			indices.Enqueue(0);
			while (nodes.Count > 0)
			{
				int index = indices.Dequeue();
				int left = index * 2 + 1, right = index * 2 + 2;
				BinaryTreeNode curr = nodes.Dequeue();
				if (left < list.Count && list[left] != null)
				{
					curr.Left = new BinaryTreeNode(list[left].Value);
					nodes.Enqueue(curr.Left);
					indices.Enqueue(left);
				}
				if (right < list.Count && list[right] != null)
				{
					curr.Right = new BinaryTreeNode(list[right].Value);
					nodes.Enqueue(curr.Right);
					indices.Enqueue(right);
				}
			}
		}

		public BinaryTreeNode Root
		{
			get => this.root;
		}

		public IList<int> Inorder_Recursive(BinaryTreeNode root) {
			IList<int> res = new List<int>();
			Inorder(root, res);
			return res;
		}

		public IList<int> Preorder_Recursive(BinaryTreeNode root) {
			IList<int> res = new List<int>();
			Preorder(root, res);
			return res;
		}

		public IList<int> Postorder_Recursive(BinaryTreeNode root)
		{
			IList<int> res = new List<int>();
			Postorder(root, res);
			return res;
		}

		public int Height(BinaryTreeNode root) {
			if (root == null) return 0;
			int left = Height(root.Left);
			int right = Height(root.Right);
			return Math.Max(left, right)+1;
		}

		public IList<int> Preorder_Iterative(BinaryTreeNode root) {
			IList<int> res = new List<int>();
			Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
			BinaryTreeNode curr = root;
			while (curr!=null || stack.Count>0)
			{
				while (curr!=null) {
					stack.Push(curr);
					res.Add(curr.Value);
					curr = curr.Left;
				}
				curr = stack.Pop();
				curr = curr.Right;
			}
			return res;
		}

		public IList<int> Inorder_Iterative(BinaryTreeNode root) {
			var res = new List<int>();
			Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
			BinaryTreeNode curr = root;
			while (curr!=null || stack.Count>0) {
				while (curr!=null) {
					stack.Push(curr);
					curr = curr.Left;
				}
				curr = stack.Pop();
				res.Add(curr.Value);
				curr = curr.Right;
			}
			return res;

		}

		public IList<int> Postorder_Iterative(BinaryTreeNode root) {
			IList<int> res = new List<int>();
			Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
			BinaryTreeNode curr = root;
			while (curr!=null || stack.Count>0) {
				while (curr!=null) {
					if (curr.Right != null) stack.Push(curr.Right);
					stack.Push(curr);
					curr = curr.Left;
				}
				curr = stack.Pop();
				if (stack.Count>0 && curr.Right != null && stack.Peek() == curr.Right)
				{
					BinaryTreeNode right = stack.Pop();
					stack.Push(curr);
					curr = right;
				}
				else {
					res.Add(curr.Value);
					curr = null;
				}
			}
			return res;
		}

		private void Inorder(BinaryTreeNode root, IList<int> res) {
			if (root!=null) {
				Inorder(root.Left, res);
				res.Add(root.Value);
				Inorder(root.Right, res);
			}
		}

		private void Preorder(BinaryTreeNode root, IList<int> res)
		{
			if (root != null)
			{
				res.Add(root.Value);
				Preorder(root.Left, res);
				Preorder(root.Right, res);
			}
		}

		private void Postorder(BinaryTreeNode root, IList<int> res)
		{
			if (root != null)
			{
				Postorder(root.Left, res);
				Postorder(root.Right, res);
				res.Add(root.Value);
			}
		}


	}
}
