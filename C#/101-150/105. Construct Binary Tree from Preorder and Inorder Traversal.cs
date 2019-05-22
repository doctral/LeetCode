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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return BuildTree(preorder, inorder, 0, 0, inorder.Length-1);
    }
    
    private TreeNode BuildTree(int[] preorder, int[] inorder, int currPreIndex, int inStartIndex, int inEndIndex){
        if(currPreIndex>=preorder.Length || inStartIndex>inEndIndex) return null;
        
        TreeNode root=new TreeNode(preorder[currPreIndex]);
        
        int inorderRootIndex=-1;
        for(int i=inStartIndex; i<=inEndIndex; i++){
            if(preorder[currPreIndex]==inorder[i]){
                inorderRootIndex=i;
                break;
            }
        }
        
        root.left=BuildTree(preorder, inorder, currPreIndex+1, inStartIndex, inorderRootIndex-1);
        
        //  inorderRootIndex-inStartIndex+1 is the number of tree nodes in left side of curr Root, we don't need to 
        // consider these tree nodes any longer
        root.right=BuildTree(preorder, inorder, currPreIndex+inorderRootIndex-inStartIndex+1, inorderRootIndex+1, inEndIndex);
        return root;
        
    }
}