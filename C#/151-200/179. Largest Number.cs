public class Solution {
    public string LargestNumber(int[] nums) {
        if(nums.Length==0) return "0";
        string[] strs=new string[nums.Length];
        for(int i=0; i<nums.Length; i++){
            strs[i]=nums[i]+"";
        }
        Array.Sort(strs, (x,y)=> (y+x).CompareTo(x+y) );
        if(strs[0]=="0") return "0";
        return string.Join("", strs);
    }
}