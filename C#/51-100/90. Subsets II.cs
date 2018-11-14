public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        IList<IList<int>> res=new List<IList<int>>();
        Array.Sort(nums);
        for(int i=0; i<=nums.Length; i++){
            Backtrack(res, nums, new List<int>(), 0, i);
        }
        return res;
    }
    
    private void Backtrack(IList<IList<int>> res, int[] nums, IList<int> temp, int index, int len){
        if(temp.Count==len){
            res.Add(new List<int>(temp));
            return;
        }
        for(int i=index; i<nums.Length; i++){
            if(i>index && nums[i]==nums[i-1]) continue; 
            temp.Add(nums[i]);
            Backtrack(res, nums, temp, i+1, len);
            temp.RemoveAt(temp.Count-1);
        }
    }
}