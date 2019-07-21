public class Solution {
    public int MissingNumber(int[] nums) {
        for(int i=0; i<nums.Length; i++){
            while(nums[i]!=i && nums[i]<nums.Length){
                int idx=nums[i];
                nums[i]=nums[idx];
                nums[idx]=idx;
            }
        }
        
        for(int i=0; i<nums.Length; i++){
            if(nums[i]!=i) return i;
        }
        
        return nums.Length;
    }
}