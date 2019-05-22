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
    public TreeNode SortedArrayToBST(int[] nums) {
        return BuildTree(nums, 0, nums.Length-1);
    }
    
    private TreeNode BuildTree(int[] nums, int left, int right){
        if(left>right) return null;
        
        int mid=(left+right)/2;
        TreeNode root=new TreeNode(nums[mid]);
        root.left=BuildTree(nums, left, mid-1);
        root.right=BuildTree(nums, mid+1, right);
        return root;
    }
}