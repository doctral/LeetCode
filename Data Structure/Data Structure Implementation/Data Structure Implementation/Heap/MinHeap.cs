using System;

namespace Data_Structure_Implementation.Heap
{
	public class MinHeap
	{
		private int[] heap;  // an array of elements
		private int capacity; // capacity of the array
		private int count;  // the size of heap

		public MinHeap()
		{
			this.heap = new int[20]; // default size
			this.capacity = 20;
			this.count = 0;
		}

		public MinHeap(int[] arr)
		{
			this.capacity = arr.Length*2;
			this.heap = new int[this.capacity];
			this.count = 0;

			// add each element in arr to heap and maintain the property of heap
			foreach (int ele in arr) {
				Insert(ele);
			}
		}

		public void Insert(int element) {
			if (count == capacity) {
				int[] newHeap = new int[capacity*2];
				for (int i=0; i<count; i++) {
					newHeap[i] = heap[i];
				}
				heap = newHeap;
				capacity = newHeap.Length;
			}
			heap[count] = element;  // the last element is heap[count]
			// maintain the property of heap
			int curr = count;
			while (Parent(curr)>=0 && heap[Parent(curr)]>heap[curr] ) {
				Swap(heap, curr, Parent(curr));
				curr = Parent(curr);
			}
			count++;
		}

		public int GetMin() {
			if (count == 0) throw new Exception("Error! The heap contains no elements.");
			return heap[0]; 
		}

		public int ExtractMin()
		{
			if (count == 0) throw new Exception("Error! The heap contains no elements.");
			int res = GetMin();
			heap[0] = heap[count - 1];
			int curr = 0;
			while (true)
			{
				bool left = false, right = false;
				if (LeftChild(curr) < count - 1 && heap[LeftChild(curr)] < heap[curr]) left = true;
				if (RightChild(curr) < count - 1 && heap[RightChild(curr)] < heap[curr]) right = true;
				if (!left && !right) break;
				if (left && right)
				{
					if (heap[LeftChild(curr)] < heap[RightChild(curr)])
					{
						Swap(heap, curr, LeftChild(curr));
						curr = LeftChild(curr);
					}
					else
					{
						Swap(heap, curr, RightChild(curr));
						curr = RightChild(curr);
					}
				}
				else if (left)
				{
					Swap(heap, curr, LeftChild(curr));
					curr = LeftChild(curr);
				}
				else
				{
					Swap(heap, curr, RightChild(curr));
					curr = RightChild(curr);
				}
			}
			heap[count - 1] = 0;
			count--;
			return res;
		}

		public int Count {
			get {
				return count;
			}
		}

		private int Parent(int index) {
			return (index - 1) / 2;
		}

		private int LeftChild(int index) {
			return index * 2 + 1;
		}

		private int RightChild(int index) {
			return index * 2 + 2;
		}

		private void Swap(int[] arr, int idx1, int idx2) {
			int temp = arr[idx1];
			arr[idx1] = arr[idx2];
			arr[idx2] = temp;
		}
	}
}
