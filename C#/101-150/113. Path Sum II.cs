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
    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        IList<IList<int>> res=new List<IList<int>>();
        if(root==null) return res;
        GetPathSum(res, new List<int>(), root, sum);
        return res;
    }
    
    private void GetPathSum(IList<IList<int>> res, IList<int> temp, TreeNode root, int sum){
        if(root==null){
            if(sum==0){
                res.Add(new List<int>(temp));
            }
            return;
        }
        temp.Add(root.val);
        if(root.left==null){
            GetPathSum(res, temp, root.right, sum-root.val);
        }
        else if(root.right==null){
            GetPathSum(res, temp, root.left, sum-root.val);
        }
        else{
            GetPathSum(res, temp, root.left, sum-root.val);
            GetPathSum(res, temp, root.right, sum-root.val);
        }
        temp.RemoveAt(temp.Count-1);
    }
}