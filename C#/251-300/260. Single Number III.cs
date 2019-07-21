public class Solution {
    public int[] SingleNumber(int[] nums) {
        int[] res=new int[2];
        int temp=0;
        foreach(int num in nums) temp=temp^num;
        int idx=0;
        while(idx<32){
            if( ((temp>>idx)&1) ==1  ) break;
            idx++;
        }
        
        foreach(int num in nums){
            if( ((num>>idx) & 1)==0 ){
                res[0]=res[0]^num;
            }
        }
        
        res[1] = temp^res[0];
        
        return res;
    }
}