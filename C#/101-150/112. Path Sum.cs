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
    public bool HasPathSum(TreeNode root, int sum) {
        if(root==null) return false;
        return PathSum(root, sum);
    }
    
    private bool PathSum(TreeNode root, int sum){
        if(root==null) return sum==0;
        if(root.left==null) return PathSum(root.right, sum-root.val);
        if(root.right==null) return PathSum(root.left, sum-root.val);
        return PathSum(root.left, sum-root.val) || PathSum(root.right, sum-root.val);
    }
}