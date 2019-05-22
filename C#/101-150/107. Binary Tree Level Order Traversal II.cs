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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        IList<IList<int>> res=new List<IList<int>>();
        if(root==null) return res;
        
        IList<IList<TreeNode>> nodes=new List<IList<TreeNode>>();
        IList<TreeNode> curr=new List<TreeNode>();
        curr.Add(root);
        
        while(curr.Count>0){
            nodes.Add(new List<TreeNode>(curr));
            
            IList<TreeNode> next=new List<TreeNode>();
            foreach(TreeNode node in curr){
                if(node.left!=null) next.Add(node.left);
                if(node.right!=null) next.Add(node.right);
            }
            
            curr=next;
        }
        
        for(int i=nodes.Count-1; i>=0; i--){
            IList<int> temp=new List<int>();
            
            foreach(var node in nodes[i]){
                temp.Add(node.val);
            }
            res.Add(new List<int>(temp));
        }
        
        return res;
    }
}