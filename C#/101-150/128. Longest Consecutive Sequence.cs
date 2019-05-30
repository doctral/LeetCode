public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> numbers=new HashSet<int>(nums);
        int res=0;
        for(int i=0; i<nums.Length && numbers.Count>res; i++){
            if(!numbers.Contains(nums[i])) continue;
            int count=1, left=nums[i], right=nums[i];
            numbers.Remove(nums[i]);
            while(numbers.Contains(left-1)){
                count++;
                left--;
                numbers.Remove(left);
            }
            while(numbers.Contains(right+1)){
                count++;
                right++;
                numbers.Remove(right);
            }
            
            if(res<count) res=count;
        }
        
        return res;
    }
}