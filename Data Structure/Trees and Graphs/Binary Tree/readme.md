# Binary Tree & Binart Search Tree

## Useful resources
1. [Binary Tree & Binary Search Tree](https://msdn.microsoft.com/en-us/library/ms379572(v=vs.80).aspx)

## Binary Tree
1. Binary Tree: a binary tree is a tree in which each node has up to two children.
2. **Complete binary tree**: every level except possibly the last level is completely filled, and all nodes are as far left as possible.
3. **Full binary tree**: every node has either zero or two children.
4. **Perfect binary tree**: binary tree both complete and full.
5. Tree Traversal:
    1. Inorder: left, root, right
    2. Preorder: root, left, right
    3. Postorder: left, right. root

## Binary Search Tree
1. A binary Search Tree is a binary tree in which every node fits a specific ordering property: ALL LEFT DESCENDENTS <= PARENT < ALL RIGHT 
2. For a reasonable "balanced" binary search tree, the insertion, look up, and deletion operations can all be done in O(log n) time.

 

Two common types of balanced trees are red-black trees and AVL trees.





A binary search tree can be implemented using a linked structure. 

Deleting Elements from a BST:
Case 1: Node is a leaf node: This is a simple case, figure out whether this node is left or right node of parent 
        and set null as child for the parent for that side.
Case 2: Node is having one child: Establish a direct link between parent node and child node of this node.
Case 3: Node has two children: This is little tricky.. the steps involved in this are.
        Step 1: First find the successor (or predessor) of the this node.
        Step 2: Delete the successor (or predessor) from the tree.
        Step 3: Replace the node to be deleted with the successor (or predessor)



BFS for a Binary Search Tree:
    Method 1: Recursion
    /*Function to print level order traversal of tree*/
    printLevelorder(tree)
    for d = 1 to height(tree)
         printGivenLevel(tree, d);

    /*Function to print all nodes at a given level*/
    printGivenLevel(tree, level)
    if tree is NULL then return;
    if level is 1, then
        print(tree->data);
    else if level greater than 1, then
        printGivenLevel(tree->left, level-1);
        printGivenLevel(tree->right, level-1);
        
    Method 2: Using a Queue
    printLevelorder(tree)
    1) Create an empty queue q
    2) temp_node = root /*start from root*/
    3) Loop while temp_node is not NULL
        a) print temp_node->data.
        b) Enqueue temp_node’s children (first left then right children) to q
        c) Dequeue a node from q and assign it’s value to temp_node

DFS for a Binary Search Tree: preorder traversal would visit nodes as DFS

postOrder traversal algorithm of a Binary Tree:
    1.1 Create an empty stack
        curr=root
    2.1 while(stack is not empty || curr!=null) 
              while(curr!=null)
                    if curr.right!=null
                        stack.push(curr.right)
                    stack.push(curr)
                    curr=curr.left
             curr=stack.pop()
             if(curr.right!=null && curr.right==stack.peek() )
                 temp=stack.pop()
                 stack.push(curr)
                 curr=temp
             else
                 print curr.element
                 curr=null
    
