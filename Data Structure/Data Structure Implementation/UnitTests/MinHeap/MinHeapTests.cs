using System;
using Xunit;

namespace UnitTests.MinHeap
{
	public class MinHeapTests
	{
		[Fact]
		public void WhenCreate_MinHeap_WithDefaultConstructor_ShouldReturnEmptyMinHeap() {
			// Arrange

			// Act
			var heap = new Data_Structure_Implementation.Heap.MinHeap();

			// Assert
			Assert.Equal(0, heap.Count);
			Exception ex = Assert.Throws<Exception>(() => heap.GetMin());
			Exception ex2 = Assert.Throws<Exception>(() => heap.ExtractMin());
			Assert.Equal("Error! The heap contains no elements.", ex.Message);
			Assert.Equal("Error! The heap contains no elements.", ex2.Message);
		}

		[Fact]
		public void WhenCreate_MinHeap_WithAnNonEmptyArray_ShouldReturnMinHeap() {
			// Arrange
			int[] arr = new int[] {29, 10, 13, 1, 5, 22, 5, 4, 15, -1};

			// Act
			var heap = new Data_Structure_Implementation.Heap.MinHeap(arr);

			// Assert
			Assert.Equal(arr.Length, heap.Count);
			Assert.Equal(-1, heap.GetMin());
		}

		[Fact]
		public void WhenCalling_Insert_WithEmptyMinHeap_ShouldIncreaseCountAndUpdateMin() {
			// Arrange

			// Act
			var heap = new Data_Structure_Implementation.Heap.MinHeap();
			heap.Insert(29);
			heap.Insert(10);
			heap.Insert(13);
			heap.Insert(1);
			heap.Insert(22);
			heap.Insert(-1);
			// Assert

			Assert.True(heap.Count == 6);
			Assert.Equal(-1, heap.GetMin());
		}

		[Fact]
		public void WhenCalling_Insert_WithNonEmptyHeap_ShouldIncreaseCountAndUpdateMin() {
			// Arrange
			int[] arr = new int[] { 40};
			
			// Act
			var heap = new Data_Structure_Implementation.Heap.MinHeap(arr);
			heap.Insert(29);
			heap.Insert(33);
			heap.Insert(24);
			heap.Insert(13);
			heap.Insert(19);

			// Assert
			Assert.Equal(6, heap.Count);
			Assert.Equal(13, heap.GetMin());
		}

		[Fact]
		public void WhenCalling_ExtractMin_ShouldDecreaseCountAndUpdateMin() {
			// Arrange
			int[] arr = new int[] { 29, 10, 13, 1, 5, 22, 5, 4, 15, -1 };
			// Act
			var heap = new Data_Structure_Implementation.Heap.MinHeap(arr);

			// Assert
			Assert.Equal(arr.Length, heap.Count);
			Assert.Equal(-1, heap.ExtractMin());
			Assert.Equal(9, heap.Count);
			Assert.Equal(1, heap.ExtractMin());
			Assert.Equal(8, heap.Count);
			Assert.Equal(4, heap.ExtractMin());
			Assert.Equal(7, heap.Count);
			Assert.Equal(5, heap.ExtractMin());
			Assert.Equal(6, heap.Count);
			Assert.Equal(5, heap.ExtractMin());
			Assert.Equal(5, heap.Count);
			Assert.Equal(10, heap.ExtractMin());
			Assert.Equal(4, heap.Count);
			Assert.Equal(13, heap.ExtractMin());
			Assert.Equal(3, heap.Count);
			Assert.Equal(15, heap.ExtractMin());
			Assert.Equal(2, heap.Count);
			Assert.Equal(22, heap.ExtractMin());
			Assert.Equal(1, heap.Count);
			Assert.Equal(29, heap.ExtractMin());
			Assert.Equal(0, heap.Count);
			Assert.Throws<Exception>(()=>heap.ExtractMin());
		}
	}
}
