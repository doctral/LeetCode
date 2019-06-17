public class Solution {
    public void Rotate(int[] nums, int k) {
        k=k%nums.Length;
        Rotate(nums, 0, nums.Length-1);
        Rotate(nums, 0, k-1);
        Rotate(nums, k, nums.Length-1);
    }
    
    private void Rotate(int[] nums, int left, int right){
        int temp=0;
        while(left<right){
            temp=nums[left];
            nums[left]=nums[right];
            nums[right]=temp;
            left++;
            right--;
        }
    }
}