public class Solution {
    public bool IsScramble(string s1, string s2) {
        if(s1.Length<=1) return s1==s2;
        // assume all chars are lower case from 'a' to 'z'
        // need to confirm with interviewer, no big deal though
        // check is s1 and s2 has the same chars
        int[] record=new int[26];
        for(int i=0; i<s1.Length; i++){
            record[s1[i]-'a']++;
            record[s2[i]-'a']--;
        }
        foreach(int c in record){
            if(c!=0) return false;
        }

        // if s1 and s2 are scramble, and their substrings must be scramble as well, we check this recursively.
        // two non-empty substrings
        for(int i=1; i<s1.Length; i++){
            if(IsScramble(s1.Substring(0, i), s2.Substring(0,i)) && IsScramble(s1.Substring(i, s1.Length-i), s2.Substring(i, s2.Length-i)) ) return true;
            if(IsScramble(s1.Substring(0,i), s2.Substring(s2.Length-i,i) ) && IsScramble( s1.Substring(i, s1.Length-i), s2.Substring(0,s1.Length-i) )) return true;
        }
        return false;
    }
}