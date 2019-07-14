public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        if(t<0) return false;
        SortedSet<long> ss=new SortedSet<long>();
        for(int i=0; i<nums.Length; i++){
            if(ss.GetViewBetween((long)nums[i]-t, (long)nums[i]+t).Count>0) return true;
            ss.Add(nums[i]);
            if(i>=k) ss.Remove(nums[i-k]);
        }
        return false;
    }
}