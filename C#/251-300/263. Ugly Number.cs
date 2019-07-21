public class Solution {
    public bool IsUgly(int num) {
        if(num<1) return false;
        if(num<7) return true;
        while(num>=7){
            if(num%5==0){
                num=num/5;
            }
            else if(num%3==0){
                num=num/3;
            }
            else if(num%2==0){
                num=num/2;
            }
            else{
                return false;
            }
        }
        return true;
    }
}