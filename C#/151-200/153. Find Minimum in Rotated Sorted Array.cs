public class Solution {
    public int FindMin(int[] nums) {
        int min = Int32.MaxValue;
        int left=0, right=nums.Length-1;
        while(left<=right){
            int mid=(left+right)/2;
            if(nums[mid]>=nums[left]){
                if(nums[left]<min){
                    min=nums[left];
                }
                left=mid+1;
            }
            else{
                if(nums[mid]<min) min=nums[mid];
                right=mid-1;
            }
        }
        return min;
    }
}