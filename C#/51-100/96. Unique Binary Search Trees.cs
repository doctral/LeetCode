public class Solution {

    // given number from 1 to n, assume we pick up i as root, then number from 1 tp i-1 would be in the left branch,
    // and number i+1 to n would be in the right branch
    // assume there are x1 structures in left branch, and x2 structures in right branch, then for root i, there are x1 * x2 unique trees
    // therefore, we can solve this problem using DP.
    public int NumTrees(int n) {
        if(n<=0) return 0;
        int[] res=new int[n+1];
        res[0]=1;
        res[1]=1;
        for(int i=2; i<=n; i++){
            for(int root=1; root<=i; root++){
                int left=res[root-1]; // there is (root-1) nodes in left branch  
                int right=res[i-root]; // there is (i-root) nodes in right branch
                res[i]+=left*right;
            }
        }
        return res[n];
    }
}