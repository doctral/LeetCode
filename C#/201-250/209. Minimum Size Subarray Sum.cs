public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        int left=0, minLen=nums.Length+1, sum=0;
        for(int i=0; i<nums.Length; i++){
            sum+=nums[i];
            while(sum>=s){
                minLen=Math.Min(minLen, i-left+1);
                sum=sum-nums[left];
                left++;
            }
        }
        return minLen==nums.Length+1? 0: minLen;
    }
}