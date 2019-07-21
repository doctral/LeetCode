public class Solution {
    public int FindDuplicate(int[] nums) {
        int slow=nums[0], fast=nums[0];
        do{
            slow=nums[slow];
            fast=nums[nums[fast]];
        }
        while(slow!=fast);
        
        int start=nums[0];
        while(start!=slow){
            start=nums[start];
            slow=nums[slow];
        }
        return start;
    }
}