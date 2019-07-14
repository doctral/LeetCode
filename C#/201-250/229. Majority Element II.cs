public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        IList<int> res=new List<int>();
        int num1=0, num2=0, count1=0, count2=0;
        foreach(int num in nums){
            if(num==num1){
                count1++;
            }
            else if(num==num2){
                count2++;
            }
            else if(count1==0){
                num1=num;
                count1++;
            }
            else if(count2==0){
                num2=num;
                count2++;
            }
            else {
                count1--;
                count2--;
            }
        }
        
        int c1=0, c2=0;
        foreach(int num in nums){
            if(num==num1) c1++;
            if(num==num2) c2++;
        }
        
        if(c1>nums.Length/3) res.Add(num1);
        if(num1!=num2 && c2>nums.Length/3) res.Add(num2);
        return res;
    }
}