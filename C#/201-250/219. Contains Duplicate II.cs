public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        Dictionary<int, IList<int>> map=new Dictionary<int, IList<int>>();
        for(int i=0; i<nums.Length; i++){
            if(!map.ContainsKey(nums[i])) map[nums[i]]=new List<int>();
            map[nums[i]].Add(i);
        }
        
        foreach(int key in map.Keys){
            if(map[key].Count<2) continue;
            for(int i=1; i<map[key].Count; i++){
                if(map[key][i]-map[key][i-1]<=k) return true;
            }
        }
        return false;
    }
}