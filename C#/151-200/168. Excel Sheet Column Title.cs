public class Solution {
    public string ConvertToTitle(int n) {
        StringBuilder sb=new StringBuilder();
        while(n>0){
            n--;
            sb.Insert(0, (char)(n%26+'A') );
            n=n/26;
        }
        return sb.ToString();
    }
}