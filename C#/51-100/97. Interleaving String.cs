public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        if(s1.Length+s2.Length!=s3.Length) return false;
        bool[,] res=new bool[s1.Length+1,s2.Length+1];
        res[0,0]=true;
        for(int i=0; i<s1.Length; i++){
            res[i+1,0] = res[i,0] && s3[i]==s1[i]; 
        }
        for(int i=0; i<s2.Length; i++){
            res[0,i+1] = res[0,i] && s3[i]==s2[i];
        }
        for(int i=0; i<s1.Length; i++){
            for(int j=0; j<s2.Length; j++){
                res[i+1,j+1] = res[i,j+1] && s1[i]==s3[i+j+1]
                                || res[i+1,j] && s2[j]==s3[i+j+1];
            }
        }
        return res[s1.Length,s2.Length];
    }
}