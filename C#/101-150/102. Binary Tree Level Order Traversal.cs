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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> res=new List<IList<int>>();
        if(root==null) return res;
        Queue<TreeNode> curr=new Queue<TreeNode>();
        curr.Enqueue(root);
        
        while(curr.Count>0){
            Queue<TreeNode> next=new Queue<TreeNode>();
            IList<int> temp=new List<int>();
            while(curr.Count>0){
                TreeNode node=curr.Dequeue();
                temp.Add(node.val);
                if(node.left!=null) next.Enqueue(node.left);
                if(node.right!=null) next.Enqueue(node.right);
            }
            res.Add(temp);
            curr=next;
        }
        
        return res;
    }
}