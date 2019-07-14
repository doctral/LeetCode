public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if(nums.Length<2 || k<2) return nums;
        int[] res=new int[nums.Length-k+1];
        int left=0, right=k-1, maxIndex=-1;
        while(right<nums.Length){
            if(maxIndex<left){
                maxIndex=left;
                for(int i=left+1; i<=right; i++){
                    if(nums[i]>nums[maxIndex]) maxIndex=i;
                }
            }
            else if(nums[right]>nums[maxIndex]){
                maxIndex=right;
            }
            res[left]=nums[maxIndex];
            left++;
            right++;
        }
        
        return res;
    }
}