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
    private int res=Int32.MinValue;
    public int MaxPathSum(TreeNode root) {
        DFS(root);
        return res;
    }
    
    private int DFS(TreeNode root){
        if(root==null) return 0;
        int left=Math.Max(DFS(root.left), 0);
        int right=Math.Max(DFS(root.right), 0);
        res=Math.Max(res, left+right+root.val);
        return Math.Max(left, right)+root.val;
    }
}