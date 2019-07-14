public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length<2) return nums.Length==0? 0 : nums[0];
        
        int max=0;
        
        // if take first, then we don't need to consider the last number
        int[] firstMax=new int[nums.Length];
        for(int i=0; i<nums.Length-1; i++){
            if(i<2){
                firstMax[i]= (i==0)? nums[i] : Math.Max(nums[i-1], nums[i]);
            }
            else{
                firstMax[i] = Math.Max(firstMax[i-1], firstMax[i-2]+nums[i]);
            }
            if(max<firstMax[i]) max=firstMax[i];
        }
        
        // if don't take the first one, then we can include the last number
        int[] secondMax=new int[nums.Length];
        for(int i=1; i<nums.Length; i++){
            if(i<3){
                secondMax[i]= (i==1)? nums[i] : Math.Max(nums[i], nums[i-1]);
            }
            else{
                secondMax[i]=Math.Max(secondMax[i-1], secondMax[i-2]+nums[i]);
            }
            
            if(max<secondMax[i]) max=secondMax[i];
        }
        
        return max;
    }
}