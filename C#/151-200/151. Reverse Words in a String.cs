public class Solution {
    public string ReverseWords(string s) {
        string[] strs=s.Split(' ');
        StringBuilder sb=new StringBuilder();
        for(int i=strs.Length-1; i>=0; i--){
            if(strs[i].Length>0){
                sb.Append(strs[i]+" ");
            }
        }
        
        return sb.Length>0? sb.ToString().Substring(0, sb.Length-1) : "";
    }
}