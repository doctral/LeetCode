public class Solution {
    public int HammingWeight(uint n) {
        int res=0;
        for(int i=0; i<32; i++){
            if( (n&1) == 1 ) res++;
            n=n>>1;
        }
        return res;
    }
}