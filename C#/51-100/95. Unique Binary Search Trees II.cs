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
    public IList<TreeNode> GenerateTrees(int n) {
        if(n<=0) return new List<TreeNode>();
        return GenerateTrees(1,n);        
    }
    
    private IList<TreeNode> GenerateTrees(int min, int max){
        var res=new List<TreeNode>();
        if(min>max){
            res.Add(null);
            return res;
        }

        // we use i as root node, then all min to i-1 would be in left branch, and i+1 to max would be in right branch
        for(int i=min; i<=max; i++){
            var leftBranch=GenerateTrees(min, i-1);
            var rightBranch=GenerateTrees(i+1, max);

            // we collect all possible combinations here
            foreach(var left in leftBranch){
                foreach(var right in rightBranch){
                    var root=new TreeNode(i);
                    root.left=left;
                    root.right=right;
                    res.Add(root);
                }                
            }
        }
        return res;
    }
}