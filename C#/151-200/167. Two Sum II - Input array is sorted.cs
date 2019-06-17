public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int[] res=new int[2];
        int left=0, right=numbers.Length-1;
        while(left<right){
            int sum=numbers[left]+numbers[right];
            if(sum==target){
                res[0]=left+1;
                res[1]=right+1;
                break;
            }
            if(sum<target){
                left++;
            }
            else{
                right--;
            }
        }
        return res;
    }
}