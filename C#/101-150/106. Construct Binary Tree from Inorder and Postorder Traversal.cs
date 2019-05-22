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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        return BuildTree(inorder, postorder, postorder.Length-1, 0, inorder.Length-1);
    }
    
    private TreeNode BuildTree(int[] inorder, int[] postorder, int postIndex, int inStart, int inEnd){
       if(postIndex<0 || inStart>inEnd) return null;
       
        TreeNode root=new TreeNode(postorder[postIndex]);
        
        int rootIndex=-1;
        for(int i=inStart; i<=inEnd; i++){
            if(inorder[i]==postorder[postIndex]){
                rootIndex=i;
                break;
            }
        }
        
        root.right=BuildTree(inorder, postorder, postIndex-1, rootIndex+1, inEnd);
        root.left=BuildTree(inorder, postorder, postIndex-(inEnd-rootIndex+1), inStart, rootIndex-1);
        
        return root;
    }
}