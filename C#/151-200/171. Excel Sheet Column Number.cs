public class Solution {
    public int TitleToNumber(string s) {
        int res=0;
        foreach(char ch in s){
            res=res*26 + (ch-'A'+1);
        }
        return res;
    }
}