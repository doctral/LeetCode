public class Solution {
    public int MaximumGap(int[] nums) {
        if(nums.Length<2) return 0;
        int max=0;
        foreach(int num in nums){
            if(num>max) max=num;
        }
        RadixSort(nums, max);
        int res=0;
        for(int i=1; i<nums.Length; i++){
            if(nums[i]-nums[i-1]>res) res=nums[i]-nums[i-1];
        }
        return res;
    }
    
    private void RadixSort(int[] nums, int max){
        int[] temp=new int[nums.Length];
        int b=1;
        while(max/b>0){
            int[] digits=new int[10];
            foreach(int num in nums){
                digits[(num/b)%10]++;
            }
            
            for(int i=1; i<10; i++){
                digits[i]+=digits[i-1];
            }
            
            for(int i=nums.Length-1; i>=0; i--){
                temp[--digits[(nums[i]/b)%10]]=nums[i];
            }
            
            for(int i=0; i<temp.Length; i++){
                nums[i]=temp[i];
            }
            b=b*10;
        }
    }
}