public class Solution {
    public int FindMin(int[] nums) {
        int min=Int32.MaxValue;
        int left=0, right=nums.Length-1;
        while(left<=right){
            int mid=(left+right)/2;
            if(nums[mid]>=nums[left] && nums[mid]>nums[right]){
                if(min>nums[left]) min=nums[left];
                left=mid+1;
            }
            else if(nums[left]>nums[mid] && nums[mid]<=nums[right]){
                if(min>nums[mid]) min=nums[mid];
                right=mid-1;
            }
            else{
                if(min>nums[left]) min=nums[left];
                left++;
                right--;
            }
        }
        return min;
    }
}