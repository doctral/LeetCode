public class Solution {
    public int Rob(int[] nums) {
        int max=0;
        int[] temp=new int[nums.Length];
        for(int i=0; i<nums.Length; i++){
            if(i<2){
                temp[i]=(i==0)? nums[i]: Math.Max(nums[i-1], nums[i]);
            }
            else{
                temp[i]=Math.Max(temp[i-2]+nums[i], temp[i-1]);
            }
            if(max<temp[i]) max=temp[i];
        }
        return max;
    }
}