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
    public IList<int> RightSideView(TreeNode root) {
        if(root==null) return new List<int>();
        
        IList<IList<TreeNode>> all=new List<IList<TreeNode>>();
        IList<TreeNode> curr=new List<TreeNode>();
        curr.Add(root);
        
        while(curr.Count>0){
            all.Add(new List<TreeNode>(curr));
            IList<TreeNode> next=new List<TreeNode>();
            foreach(TreeNode node in curr){
                if(node.left!=null) next.Add(node.left);
                if(node.right!=null) next.Add(node.right);
            }
            curr=next;
        }
        
        IList<int> res=new List<int>();
        foreach(IList<TreeNode> list in all){
            res.Add(list[list.Count-1].val);
        }
        return res;
    }
}