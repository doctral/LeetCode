public class Solution {
    public int LengthOfLIS(int[] nums) {
        int[] arr=new int[nums.Length];
        int size=0;
        // index size is for incoming new element in subsequence array
        for(int i=0; i<nums.Length; i++){
            int left=0, right=size;
            while(left<right){
                int mid=(right-left)/2+left;
                if(nums[i]>arr[mid]){
                    left=mid+1;
                }
                else{
                    right=mid;
                }
            }
            arr[left]=nums[i];
            if(left==size) size++;
        }
        return size;
    }
}