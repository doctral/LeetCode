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
    public int KthSmallest(TreeNode root, int k) {
        int left=Count(root.left);
        if(k-left==1) return root.val;
        if(k<=left) return KthSmallest(root.left, k);
        return KthSmallest(root.right, k-left-1);
    }
    
    private int Count(TreeNode root){
        if(root==null) return 0;
        return 1 + Count(root.left) + Count(root.right);
    }
}