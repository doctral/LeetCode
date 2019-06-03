/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        IList<int> res=new List<int>();
        Stack<TreeNode> stack=new Stack<TreeNode>();
        while(stack.Count>0 || root!=null){
            while(root!=null){
                if(root.right!=null) stack.Push(root.right);
                stack.Push(root);
                root=root.left;
            }
            root=stack.Pop();
            if(stack.Count>0 && root.right!=null && root.right==stack.Peek()){
                TreeNode temp=stack.Pop();
                stack.Push(root);
                root=temp;
            }
            else{
                res.Add(root.val);
                root=null;
            }
        }
        
        return res;
    }
}