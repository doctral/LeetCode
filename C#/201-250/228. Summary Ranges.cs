public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        IList<string> res=new List<string>();
        if(nums.Length<1) return res;
        int index = 0;
        while(index<nums.Length){
            int left = nums[index], right = nums[index];
            while(index+1< nums.Length && nums[index+1]==right+1 ){
                right++;
                index++;
            }
            string str = left==right? left+"" : left + "->" +right;    
            res.Add(str);
            index++;
        }
        
        return res;
    }
}