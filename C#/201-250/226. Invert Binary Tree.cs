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
    public TreeNode InvertTree(TreeNode root) {
        if(root==null) return null;
        Invert(root);
        return root;
    }
    
    private void Invert(TreeNode root){
        if(root.left==null && root.right==null) return;
        TreeNode temp=root.right;
        root.right=root.left;
        root.left=temp;
        if(root.left!=null) Invert(root.left);
        if(root.right!=null) Invert(root.right);
    }
}