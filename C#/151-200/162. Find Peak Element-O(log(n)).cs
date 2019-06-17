public class Solution {
    public int FindPeakElement(int[] nums) {
        int left=0, right=nums.Length-1;
        while(left<right){
            int mid=(left+right)/2;
            
            // if nums[mid] > nums[mid+1], then there is always a peak number in the left side 
            if(nums[mid]>nums[mid+1]){
                right=mid;
            }
            
            // if nums[mid+1]>=nums[mid], then there is always a peak number in the right side
            else{
                left=mid+1;
            }
        }
        return left;
    }
}