/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class BSTIterator {

    Stack<TreeNode> stack;
    public BSTIterator(TreeNode root) {
        stack=new Stack<TreeNode>();
        while(root!=null){
            stack.Push(root);
            root=root.left;
        }
    }
    
    /** @return the next smallest number */
    public int Next() {
        TreeNode curr=stack.Pop();
        int res=curr.val;
        curr=curr.right;
        while(curr!=null){
            stack.Push(curr);
            curr=curr.left;
        }
        return res;
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return stack.Count>0;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */