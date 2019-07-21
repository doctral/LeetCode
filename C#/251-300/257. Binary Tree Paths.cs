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
    public IList<string> BinaryTreePaths(TreeNode root) {
        IList<string> res=new List<string>();
        if(root!=null) DFS(res, "", root);
        return res;
    }
    
    private void DFS(IList<string> res, string curr, TreeNode root){
        if(root.left==null && root.right==null){
            res.Add(curr+root.val);
            return;
        }
        
        if(root.left!=null) DFS(res, curr+root.val+"->", root.left);
        if(root.right!=null) DFS(res, curr+root.val+"->", root.right);
    }
}