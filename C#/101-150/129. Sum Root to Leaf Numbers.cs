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
    private int res=0;
    public int SumNumbers(TreeNode root) {
        if(root==null) return 0;
        Cal(root, 0);
        return res;
    }
    
    private void Cal(TreeNode root, int pre){
        if(root.left==null && root.right==null){
            res+=pre*10+root.val;
            return;
        }
        if(root.left!=null){
            Cal(root.left, pre*10+root.val);
        }
        if(root.right!=null){
            Cal(root.right, pre*10+root.val);
        }
    }
}