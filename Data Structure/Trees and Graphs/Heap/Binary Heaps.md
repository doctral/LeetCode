Useful resource for [Heap](https://www.geeksforgeeks.org/binary-heap/)
Min-heap and max-heap are essentially equivalent, but one is descending order, and the other is ascending order.

Min-heap is a complete binary tree where each node is smaller than its children, the root therefore is the minimum element in the tree. 

Arr[(i-1)/2]  --> return the parent node
Arr[2*i+1] --> return the left child 
Arr[2*i+2] --> return the right child 

Two key operations in heap: insert and extract_min.
    Insert: 1. Insert the new element at the bottom
            2. Fix the tree by swapping the new element with its parent, until we find an apporiate spot for the element. We   
               essentially bubble up the minimum element. O(log N).
    Extract_min: 1. Remove the minimum element and swap it with the last element in the heap.
                 2. Bubble down this element with one of its children until the min_heap property is restored. (O(log N))
