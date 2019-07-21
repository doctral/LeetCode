public class Solution {
    public int NthUglyNumber(int n) {
        if(n<=1) return 1;
        int[] res=new int[n];
        res[0]=1;
        int idx2=0, idx3=0, idx5=0;
        for(int i=1; i<n; i++){
            res[i]=Math.Min(Math.Min(res[idx2]*2, res[idx3]*3), res[idx5]*5);
            if(res[i]==res[idx2]*2) idx2++;
            if(res[i]==res[idx3]*3) idx3++;
            if(res[i]==res[idx5]*5) idx5++;
        }
        return res[n-1];
    }
}