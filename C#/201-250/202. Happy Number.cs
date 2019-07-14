public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> list=new HashSet<int>();
        while(true){
            int temp=GetSquareSum(n);
            if(temp==1) return true;
            if(!list.Add(temp)) break;
            n=temp;
        }
        return false;
    }
    
    private int GetSquareSum(int num){
        int res=0;
        while(num>0){
            res+= (num%10)*(num%10);
            num/=10;
        }
        return res;
    }
}