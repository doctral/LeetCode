public class Solution {
    public int MaxProduct(int[] nums) {
        if(nums.Length<1) return 0;
        int res=nums[0], min=nums[0], max=nums[0];
        for(int i=1; i<nums.Length; i++){
            int temp=max;
            max=Math.Max(Math.Max(min*nums[i], nums[i]*temp), nums[i]);
            min=Math.Min(Math.Min(min*nums[i], temp*nums[i]), nums[i]);
            res=Math.Max(res, max);
        }
        return res;
    }
}