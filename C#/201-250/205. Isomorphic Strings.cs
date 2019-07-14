public class Solution {
    public bool IsIsomorphic(string s, string t) {
        Dictionary<char,char> st=new Dictionary<char,char>();
        Dictionary<char,char> ts=new Dictionary<char,char>();
        for(int i=0; i<s.Length; i++){
            if(st.ContainsKey(s[i])){
                if(st[s[i]]!=t[i]) return false;
            }
            else{
                st[s[i]]=t[i];
            }
            
            if(ts.ContainsKey(t[i])){
                if(ts[t[i]]!=s[i]) return false;
            }
            else{
                ts[t[i]]=s[i];
            }
        }
        return true;
    }
}