public class Solution {
    public IList<int> GrayCode(int n) {
        IList<int> res=new List<int>();
        res.Add(0);
        if(n==0) return res;
        for(int i=1; i<=n; i++){
            IList<int> curr=new List<int>(res);
            for(int j=res.Count-1; j>=0; j--){
                curr.Add(res[j]+ (1<<i-1) );
            }
            res=curr;
        }
        return res;
    }
}