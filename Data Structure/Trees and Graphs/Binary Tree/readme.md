# Binary Tree & Binary Search Tree

## Useful resources
1. [Binary Tree & Binary Search Tree](https://msdn.microsoft.com/en-us/library/ms379572(v=vs.80).aspx)
2. [How to handle duplicates in Binary Search Tree](https://www.geeksforgeeks.org/how-to-handle-duplicates-in-binary-search-tree/)

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
1. A binary Search Tree is a binary tree in which every node fits a specific ordering property: ALL LEFT DESCENDENTS < PARENT < ALL RIGHT 
    1. By default, a binary search tree should contain distinct keys.
    2. If duplicates allowed in binary search tree, there are two possible solutions:
        1. Allow same keys on the same side (left or right)
        2. Add Count property to Tree Node
    3. In this post, we assume the binary search tree contains distinct keys only.
2. Operations:
    1. Insert (O(log n)): we can insert iteratively or recursively
    2. Delete (O(log n)): The algorithm can be described as followings:
        1. Initialization: parent=null, curr=root
        2. Try to find the target node by updating parent & curr
            ```C#
            while(curr!=null){
                if(curr.Value<value){
                    parent=curr;
                    curr=curr.Right;
                }
                else if(curr.Value>value){
                    parent=curr;
                    curr=curr.Left;
                }
                else{     // found the target node
                    break;
                }
            }
            ```
        3. if curr is null, then there is no target node in this BST, we return false
        4. Otherwise, curr is the target node to delete and parent is its parent node (if not null). Now let's find curr's predecessor.
            1. Case 1: if curr.left == null, then curr has no predecessor, and curr only has one or even no child node. Therefore, we just need to build a direct link from parent -> curr.Right.
                1. Sub-case 1: if parent==null, then curr is the root, so we set root=curr.Right, then we done!
                2. Sub-case 2: parent!=null. Then we need to determine whether curr is the left child or right child of its parent, and then we need to build a link between curr's parent and curr.Right.
                    ```C#  
                        if(parent.Value>curr.Value) {  // left child
                            parent.Left=curr.Right;
                        }
                        else{
                            parent.Right=curr.Right;
                        }
                    ``` 
            2. Case 2: curr.left != null. Therefore, curr has predecessor in curr's left branch, and we just need to find its predecessor and replace curr with its predecessor. The predecessor of a node is always the rightmost node of curr's left branch. To find curr's predecessor, we do the following steps:
                1. Initialization: predecessorParent=curr, predecessor=curr.Left
                2. Try to find the predecessor iteratively by updating predecessorParent and predecessor:
                    ```C#
                        while(predecessor.Right!=null){
                            predecessorParent=predecessor;
                            predecessor=predecessor.Right;
                        }
                    ``` 
                3. Now we should already find the predecessor, and we just need to replace the target node with its predecessor => curr.Value=predecessor.Value
                4. Now we need to remove the predecessor node, and there are two cases:
                    1. Case 1: predecessorParent.Right != predecessor. This means one thing, curr.Left node does not have a Right branch, therefore, curr.Left itself is the predecessor and we just need to build a direct link between curr and curr.Left.Left.
                    ``` C#
                        curr.Left=predecessor.Left.
                    ```
                    2. Case 2: predecessorParent.Right == predecessor. That means curr.Left has Right branch, and predecessor is already the rightmost node in curr.Left branch. Therefore, for predecessor node, it has no right child node. Therefore, we just need to remove the predecessor by doing => 
                    ```C# 
                        predecessorParent.Right=predecessor.Left. 
                    ```
                5. Now we remove the target node successfully and we just need to return true.     

 

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
    
