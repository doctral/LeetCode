using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure_Implementation.BinaryTree
{
	public class BinarySearchTree
	{
		private BinaryTreeNode root;
		
		public BinaryTreeNode Root {
			get => this.root;
		}

		public BinarySearchTree()
		{
			this.root = null;
		}

		public BinarySearchTree(int[] arr)
		{

		}

		// Insert elements iteratively
		public void Insert_Iterative(int value) {
			if (root == null) {
				root = new BinaryTreeNode(value);
				return;
			}

			BinaryTreeNode curr = root, parent = null;

			while (curr!=null) {
				parent = curr;
				curr = (curr.Value < value) ? curr.Right : curr.Left;
			}

			if (value > parent.Value)
			{
				parent.Right = new BinaryTreeNode(value);
			}
			else {
				parent.Left = new BinaryTreeNode(value);
			}
		}

		public void Insert_Recursive(int value) {
			root = Insert(root, value);
		}

		private BinaryTreeNode Insert(BinaryTreeNode root, int value) {
			if (root == null) {
				root = new BinaryTreeNode(value);
			}
			else if (value > root.Value)
			{
				root.Right = Insert(root.Right, value);
			}
			else {
				root.Left = Insert(root.Left, value);
			}
			return root;
		}

		public bool Remove(int value) {
			BinaryTreeNode parent = null, curr = root;
			while (curr != null) {
				if (value > curr.Value)
				{
					parent = curr;
					curr = curr.Right;
				}
				else if (value < curr.Value)
				{
					parent = curr;
					curr = curr.Left;
				}
				else {
					break;
				}
			}

			if (curr == null) return false;  // not found

			// now curr is the target node to delete
			if (curr.Left == null)
			{
				if (parent == null)
				{
					root = root.Right;
				}
				else
				{
					if (parent.Value > curr.Value)
					{
						parent.Left = curr.Right;
					}
					else
					{
						parent.Right = curr.Right;
					}
				}
			}
			else {
				BinaryTreeNode predecessorParent = curr, predecessor = curr.Left;
				while (predecessor.Right != null) {
					predecessorParent = predecessor;
					predecessor = predecessor.Right;
				}

				curr.Value = predecessor.Value;
				
				if (predecessorParent.Right != predecessor)
				{
					predecessorParent.Left = predecessor.Left;
				}
				else {
					predecessorParent.Right = predecessor.Left;
				}
			}
			return true;
		}
	}
}
