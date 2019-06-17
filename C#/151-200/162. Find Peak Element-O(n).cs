public class Solution {
    public int FindPeakElement(int[] nums) {
        if(nums.Length<2) return 0;
        for(int i=0; i<nums.Length; i++){
            if(i==0){
                if(nums[i]>nums[i+1]) return i;
            }
            else if(i==nums.Length-1){
                if(nums[i]>nums[i-1]) return i;
            }
            else if(nums[i]>nums[i-1] && nums[i]>nums[i+1]){
                return i;
            }
        }
        return -1;
    }
}