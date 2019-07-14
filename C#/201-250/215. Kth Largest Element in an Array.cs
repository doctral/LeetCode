public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        int left=0, right=nums.Length-1, idx=nums.Length-k;
        while(left<right){
            int pivotIndex=Partition(nums, left, right);
            if(pivotIndex==idx) return nums[pivotIndex];
            if(pivotIndex<idx){
                left=pivotIndex+1;
            }
            else{
                right=pivotIndex-1;
            }
        }
        return nums[left];
    }
    
    private int Partition(int[] nums, int left, int right){
        int pivot=nums[right];
        int curr=left;
        for(int i=left; i<right; i++){
            if(nums[i]<=pivot){
                Swap(nums, curr, i);
                curr++;
            }
        }
        Swap(nums, curr, right);
        return curr;
    }
    
    
    private void Swap(int[] nums, int i, int j){
        if(i!=j){
            int temp=nums[i];
            nums[i]=nums[j];
            nums[j]=temp;
        }
    }
}