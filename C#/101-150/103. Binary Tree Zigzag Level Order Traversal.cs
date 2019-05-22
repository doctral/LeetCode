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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> res=new List<IList<int>>();
        if(root==null) return res;
        IList<TreeNode> curr=new List<TreeNode>();
        curr.Add(root);
        bool reverse=false;
        while(curr.Count>0){
            IList<TreeNode> next=new List<TreeNode>();
            IList<int> temp=new List<int>();
            foreach(TreeNode node in curr){
                if(node.left!=null) next.Add(node.left);
                if(node.right!=null) next.Add(node.right);
            }
            
            if(reverse){
                for(int i=curr.Count-1; i>=0; i--){
                    temp.Add(curr[i].val);
                }
            }
            else{
                foreach(TreeNode node in curr){
                    temp.Add(node.val);
                }
            }
            
            reverse=!reverse;
            curr=next;
            res.Add(temp);
        }
        
        return res;
    }
}