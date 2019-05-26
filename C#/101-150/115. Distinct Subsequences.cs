public class Solution {
    public int NumDistinct(string s, string t) {
        int[,] res=new int[t.Length+1,s.Length+1];
        
        // When t=="", then it should be 1
        // when s=="" but t.Length>=1, then res[i,0]=0
        for(int i=0; i<=s.Length; i++){
            res[0,i]=1;
        }
        
        for(int i=0; i<t.Length; i++){
            for(int j=0; j<s.Length; j++){
                res[i+1,j+1]=res[i+1,j];     // get all previous duplicates
                if(t[i]==s[j]) res[i+1,j+1]+=res[i,j];   // plus the new records
            }
        }
        
        return res[t.Length,s.Length];
    }
}