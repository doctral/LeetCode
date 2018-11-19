# Heap 

## Useful resource
1. [Heap properties and implementation](https://www.geeksforgeeks.org/binary-heap/)

## Key Points
1. Min-heap and max-heap are essentially equivalent, but one is descending order, and the other is ascending order.
2. Min-heap is a complete binary tree where each node is smaller than its children, the root therefore is the minimum element in the tree. 
3. Properties: 
   1. Arr[(i-1)/2]  --> return the parent node
   2. Arr[2*i+1] --> return the left child 
   3. Arr[2*i+2] --> return the right child 

## Heap Operations (MinHeap) 
1. GetMin(): return the root element of Min Heap, O(1)
2. ExtractMin(): remove the min element (root element) from MinHeap and replace it with the last element, and then maintain the heap property, O(log n)
3. Insert(): add a new element at the end of the tree, and then maintain the property of heap. O(log n) 
