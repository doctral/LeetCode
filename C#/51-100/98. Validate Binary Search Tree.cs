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
    public bool IsValidBST(TreeNode root) {
        return Valid(root, null, null);
    }
    
    private bool Valid(TreeNode curr, TreeNode min, TreeNode max){
        if(curr==null) return true;
        if(max!=null && curr.val>=max.val) return false;
        if(min!=null && curr.val<=min.val) return false;
        return Valid(curr.left, min, curr) && Valid(curr.right, curr, max);
    }
}