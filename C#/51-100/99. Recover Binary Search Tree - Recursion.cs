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
        IList<TreeNode> list = new List<TreeNode>();
        InOrder(root, list);
        TreeNode first = null, second = null;
        for(var i=0; i<list.Count; i++){
            if(i<list.Count-1 && first == null && list[i].val > list[i+1].val){
                first = list[i];
            }
            if(i>0 && first!=null && list[i].val < list[i-1].val){
                second = list[i];
            }
        }
        int temp = first.val;
        first.val = second.val;
        second.val = temp;
    }
    
    private void InOrder(TreeNode root, IList<TreeNode> list){
        if(root!=null){
            InOrder(root.left, list);
            list.Add(root);
            InOrder(root.right, list);
        }
    }
}