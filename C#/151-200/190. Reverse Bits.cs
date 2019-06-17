public class Solution {
    public uint reverseBits(uint n) {
       uint res=0; 
       for(int i=0; i<32; i++){
           res+= (n&1);
           n = n >> 1;
           if(i<31) res = res<<1; 
       }
        return res;
    }
}