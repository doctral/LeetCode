using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.BinaryTree
{
	public class BinaryTreeTests
	{
		[Fact]
		public void WhenCalling_BinaryTree_ForDefaultConstructor_ShouldReturnNull()
		{
			// Arrange
			var tree = new Data_Structure_Implementation.BinaryTree.BinaryTree();

			// Act
			var root = tree.Root;
			// Assert
			Assert.True(root == null);
		}

		[Theory]
		[MemberData(nameof(HeightData))]
		public void WhenCalling_Height_WithInitialization_ShouldReturnHeight(IList<int?> tree, int height)
		{
			// Arrange
			var bt = new Data_Structure_Implementation.BinaryTree.BinaryTree(tree);
			var root = bt.Root;

			// Act

			// Assert
			Assert.True(height == bt.Height(root));
		}

		[Theory]
		[MemberData(nameof(PreorderData))]
		public void WhenCalling_PreorderRecursive_ShouldReturnPreorderList(IList<int?> tree, IList<int> expected)
		{
			// Arrange
			var bt = new Data_Structure_Implementation.BinaryTree.BinaryTree(tree);
			var root = bt.Root;

			// Act
			var list = bt.Preorder_Recursive(root);

			// Assert
			Assert.True(IsSame(list, expected));
		}

		[Theory]
		[MemberData(nameof(InorderData))]
		public void WhenCalling_InorderRecursive_ShouldReturnInorderList(IList<int?> tree, IList<int> expected)
			{
			// Arrange
			var bt = new Data_Structure_Implementation.BinaryTree.BinaryTree(tree);
			var root = bt.Root;

			// Act
			var list = bt.Inorder_Recursive(root);

			// Assert
			Assert.True(IsSame(list, expected));
			}

		[Theory]
		[MemberData(nameof(PostorderData))]
		public void WhenCalling_PostorderRecursive_ShouldReturnPostorderList(IList<int?> tree, IList<int> expected) {
			// Arrange
			var bt = new Data_Structure_Implementation.BinaryTree.BinaryTree(tree);
			var root = bt.Root;

			// Act
			var list = bt.Postorder_Recursive(root);

			// Assert
			Assert.True(IsSame(list, expected));
		}

		[Theory]
		[MemberData(nameof(PreorderData))]
		public void WhenCalling_PreorderIterative_ShouldReturnPreorderList(IList<int?> tree, IList<int> expected)
		{
			// Arrange
			var bt = new Data_Structure_Implementation.BinaryTree.BinaryTree(tree);
			var root = bt.Root;

			// Act
			var list = bt.Preorder_Iterative(root);

			// Assert
			Assert.True(IsSame(list, expected));
		}

		[Theory]
		[MemberData(nameof(InorderData))]
		public void WhenCalling_InorderIterative_ShouldReturnInorderList(IList<int?> tree, IList<int> expected)
		{
			// Arrange
			var bt = new Data_Structure_Implementation.BinaryTree.BinaryTree(tree);
			var root = bt.Root;

			// Act
			var list = bt.Inorder_Iterative(root);

			// Assert
			Assert.True(IsSame(list, expected));
		}

		[Theory]
		[MemberData(nameof(PostorderData))]
		public void WhenCalling_PostorderIterative_ShouldReturnPostorderList(IList<int?> tree, IList<int> expected)
		{
			// Arrange
			var bt = new Data_Structure_Implementation.BinaryTree.BinaryTree(tree);
			var root = bt.Root;

			// Act
			var list = bt.Postorder_Iterative(root);

			// Assert
			Assert.True(IsSame(list, expected));
		}

		private bool IsSame(IList<int> list1, IList<int> list2)
		{
			if (list1.Count != list2.Count) return false;
			for (int i = 0; i < list1.Count; i++)
			{
				if (list1[i] != list2[i]) return false;
			}
			return true;
		}

		// --------------------- Fake Data ----------------------------------------------
		public static IEnumerable<object[]> PreorderData
			=> new List<object[]>
			{
				new object[]{
					new List<int?>{2,1,6,4,5,7,null, null, null, null, null, null, 8},
						new List<int>{2,1,4,5,6,7,8}
				},
				new object[]{
					new List<int?>{ 1 },
					new List<int>{1}
				},
				new object[]{
					new List<int?>{1,2, null, null, 3 },
					new List<int>{1,2,3 }
				},
				new object[]{
					new List<int?>{10, 15, 20, null, null, 1, null, null, null, null, null, null, 4},
					new List<int>{10, 15, 20, 1, 4}
				}
		};

		public static IEnumerable<object[]> InorderData
			=> new List<object[]>
			{
				new object[]{
					new List<int?>{2,1,6,4,5,7,null, null, null, null, null, null, 8},
						new List<int>{4,1,5,2,7,8,6}
				},
				new object[]{
					new List<int?>{ 1 },
					new List<int>{1}
				},
				new object[]{
					new List<int?>{1,2, null, null, 3 },
					new List<int>{2,3,1}
				},
				new object[]{
					new List<int?>{10, 15, 20, null, null, 1, null, null, null, null, null, null, 4},
					new List<int>{15, 10, 1, 4, 20}
				}
			};

		public static IEnumerable<object[]> PostorderData
			=> new List<object[]>
			{
				new object[]{
					new List<int?>{2,1,6,4,5,7,null, null, null, null, null, null, 8},
						new List<int>{4,5,1,8,7,6,2}
				},
				new object[]{
					new List<int?>{ 1 },
					new List<int>{1}
				},
				new object[]{
					new List<int?>{1,2, null, null, 3 },
					new List<int>{3,2,1}
				},
				new object[]{
					new List<int?>{10, 15, 20, null, null, 1, null, null, null, null, null, null, 4},
					new List<int>{15, 4, 1, 20, 10}
				}
			};

		public static IEnumerable<object[]> HeightData
			=> new List<object[]>
			{
				new object[]{
					new List<int?>{2,1,6,4,5,7,null, null, null, null, null, null, 8},
					4
				},
				new object[]{
					new List<int?>{ 1 },
					1
				},
				new object[]{
					new List<int?>{1,2, null, null, 3 },
					3
				},
				new object[]{
					new List<int?>{10, 15, 20, null, null, 1, null, null, null, null, null, null, 4},
					4
				}
			};
		}
}
