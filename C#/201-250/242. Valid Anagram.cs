public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length!=t.Length) return false;
        int[] res=new int[256];
        for(int i=0; i<s.Length; i++){
            res[s[i]]++;
            res[t[i]]--;
        }
        
        foreach(int num in res){
            if(num!=0) return false;
        }
        return true;
    }
}