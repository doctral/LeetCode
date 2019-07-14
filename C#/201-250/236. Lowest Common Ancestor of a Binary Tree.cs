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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(Find(p,q)) return p;
        if(Find(q,p)) return q;
        while(true){
            if(Find(root.left, p) && Find(root.left,q)){
                root=root.left;
            }
            else if(Find(root.right, p) && Find(root.right, q)){
                root=root.right;
            }
            else{
                break;
            }
        }
        return root;
    }

    
    private bool Find(TreeNode root, TreeNode target){
        if(root==null) return false;
        if(root==target) return true;
        bool left=Find(root.left, target);
        bool right=Find(root.right, target);
        return left || right;
    }
}