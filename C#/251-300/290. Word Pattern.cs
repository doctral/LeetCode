public class Solution {
    public bool WordPattern(string pattern, string str) {
        string[] strs=str.Split(' ');
        if(strs.Length!=pattern.Length) return false;
        Dictionary<char, string> ps=new Dictionary<char, string>();
        Dictionary<string, char> sp=new Dictionary<string, char>();
        for(int i=0; i<pattern.Length; i++){
            if(ps.ContainsKey(pattern[i]) && sp.ContainsKey(strs[i])){
                if(ps[pattern[i]]!=strs[i] || sp[strs[i]]!=pattern[i]) return false;
            }
            else if (ps.ContainsKey(pattern[i]) || sp.ContainsKey(strs[i])){
                return false;  
            } 
            else{
                ps[pattern[i]]=strs[i];
                sp[strs[i]]=pattern[i];   
            }
        }
        return true;
    }
}