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
    public void RecoverTree(TreeNode root) {
        TreeNode first=null, second=null, pre=null, leftRightMost=null;
        
        while(root!=null){
            if(root.left==null){
                if(pre!=null && pre.val>root.val){
                    if(first==null) first=pre;
                    second=root;
                }
                pre=root;
                root=root.right;
            }
            else{
                leftRightMost=root.left;
                while(leftRightMost.right!=null && leftRightMost.right!=root){
                    leftRightMost=leftRightMost.right;
                }
                
                if(leftRightMost.right==null){
                    leftRightMost.right=root;
                    root=root.left;
                }
                else{
                    if(pre!=null && pre.val>root.val){
                        if(first==null) first=pre;
                        second=root;
                    }
                    pre=root;
                    leftRightMost.right=null;
                    root=root.right;
                }
            }
        }
        
        if(first!=null){
            int temp=first.val;
            first.val=second.val;
            second.val=temp;
        }
    }
}