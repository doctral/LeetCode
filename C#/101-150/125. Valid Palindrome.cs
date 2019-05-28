public class Solution {
    public bool IsPalindrome(string s) {
        string str=s.ToLower();
        int left=0, right=str.Length-1;
        while(left<right){
            while(left<right && (str[left]-'a'<0 || str[left]-'z'>0) && (str[left]<'0' || str[left]>'9') ){
                left++;
            }
            
            while(left<right && (str[right]-'a'<0 || str[right]-'z'>0) && (str[right]<'0' ||str[right]>'9') ){
                right--;
            }
            
            if(left<right && str[left]!=str[right]) return false;
            left++;
            right--;
        }
        return true;
    }
}