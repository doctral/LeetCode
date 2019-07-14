public class Solution {
    public int RangeBitwiseAnd(int m, int n) {
        int res=0;
        while(m>0 && n>0){
            int msb1=GetMSB(m), msb2=GetMSB(n);
            if(msb1!=msb2) break;
            res+= (1<<msb1);
            m-=(1<<msb1);
            n-=(1<<msb1);
        }
        return res;
    }
    
    private int GetMSB(int num){
        int res=-1;
        while(num>0){
            num>>=1;
            res++;
        }
        return res;
    }
}