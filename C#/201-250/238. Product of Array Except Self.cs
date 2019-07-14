public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        if(nums.Length<1) return nums;
        int n=nums.Length;
        int[] res=new int[n];
        for(int i=0; i<n; i++){
            res[i]=1;
        }
        int left=1;
        for(int i=0; i<n; i++){
            res[i]*=left;
            left=left*nums[i];
        }
        
        int right=1;
        for(int i=n-1; i>=0; i--){
            res[i]*=right;
            right*=nums[i];
        }
        
        return res;
    }
}