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
    public IList<int> PreorderTraversal(TreeNode root) {
        IList<int> res=new List<int>();
        if(root==null) return res;
        Stack<TreeNode> stack=new Stack<TreeNode>();
        while(stack.Count>0 || root!=null){
            while(root!=null){
                stack.Push(root);
                res.Add(root.val);
                root=root.left;
            }
            root=stack.Pop().right;
        }
        return res;
    }
}