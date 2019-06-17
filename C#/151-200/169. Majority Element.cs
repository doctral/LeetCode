public class Solution {
    public int MajorityElement(int[] nums) {
        int count=1, curr=nums[0];
        for(int i=1; i<nums.Length; i++){
            if(curr==nums[i]){
                count++;
            }
            else{
                count--;
            }
            if(count==0){
                curr=nums[i];
                count++;
            }
        }
        return count>=1? curr : -1;
    }
}