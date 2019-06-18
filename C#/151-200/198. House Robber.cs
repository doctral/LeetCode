public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length==0) return 0;
        int[] max=new int[nums.Length];
        int res=0;
        for(int i=0; i<nums.Length; i++){
            if(i==0){
                max[i]=nums[i];
            }
            else if(i==1){
                max[i]=Math.Max(nums[0], nums[1]);
            }
            else{
                max[i]=Math.Max(max[i-1], max[i-2]+nums[i]);
            }
            if(res<max[i]) res=max[i];
        }
        return res;
    }
}