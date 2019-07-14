public class Solution {
    public string ShortestPalindrome(string s) {
        string rev=Reverse(s);
        int[] lps=ComputeLPS(s+"#"+rev);
        return rev.Substring(0, s.Length-lps[lps.Length-1])+s;
    }
    
    private string Reverse(string str){
        StringBuilder sb=new StringBuilder();
        foreach(char ch in str){
            sb.Insert(0, ch);
        }
        return sb.ToString();
    }
    
    private int[] ComputeLPS(string str){
        int[] lps=new int[str.Length];
        int i=1, len=0;
        lps[0]=0;
        while(i<str.Length){
            if(str[i]==str[len]){
                len++;
                lps[i]=len;
                i++;
            }
            else{
                if(len!=0){
                    len=lps[len-1];
                }
                else{
                    lps[i]=len;
                    i++;
                }
            }
        }
        return lps;
    }
}