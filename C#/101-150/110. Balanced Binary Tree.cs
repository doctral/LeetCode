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
        
    public bool IsBalanced(TreeNode root) {
        return GetHeight(root)!=-1;
    }
    
    private int GetHeight(TreeNode root){
        if(root==null) return 0;
        int left=GetHeight(root.left);
        if(left==-1) return -1;
        int right=GetHeight(root.right);
        if(right==-1 || Math.Abs(left-right)>1) return -1;
        
        return Math.Max(left, right)+1;
    }
}