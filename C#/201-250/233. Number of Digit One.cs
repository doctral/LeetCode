public class Solution {
    public int CountDigitOne(int n) {
        long res=0;
        for(long k=1; k<=n; k*=10){
            long r=n/k, m=n%k;
            res+=(r+8)/10*k+((r%10==1)?(m+1):0);
        }
        return (int)res;
    }
}