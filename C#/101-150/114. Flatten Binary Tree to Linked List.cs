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
    public void Flatten(TreeNode root) {
        while(root!=null){
            if(root.left!=null){
                TreeNode leftRightMost=root.left;
                while(leftRightMost.right!=null){
                    leftRightMost=leftRightMost.right;
                }
                leftRightMost.right=root.right;
                root.right=root.left;
                root.left=null;
            }
            root=root.right;
        }
    }
}