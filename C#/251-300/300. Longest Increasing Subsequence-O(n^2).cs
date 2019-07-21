public class Solution {
    public int LengthOfLIS(int[] nums) {
        int res=0;
        int[] record=new int[nums.Length];
        
        for(int i=0; i<nums.Length; i++){
            record[i]=1;
            for(int j=0; j<i; j++){
                if(nums[i]>nums[j] && 1+record[j]>record[i]){
                    record[i]=1+record[j];
                }
            }
            if(res<record[i]) res=record[i];
        }
        return res;
    }
}