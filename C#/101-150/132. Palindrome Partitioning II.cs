public class Solution {
    public int MinCut(string s) {
        if(s.Length<2) return 0;
        bool[,] valid=new bool[s.Length,s.Length];
        for(int len=1; len<=s.Length; len++){
            for(int start=0; start+len-1<s.Length; start++){
               if(CheckValidity(valid, s, start, start+len-1)){
                   valid[start, start+len-1]=true;
               };
            }
        }
        
        int[] res=new int[s.Length];
        for(int i=0; i<s.Length; i++){
            if(valid[0, i]){
                res[i]=0;
            }
            else{
                int temp=Int32.MaxValue;
                for(int j=1; j<=i; j++){
                    if(valid[j, i] && res[j-1]+1<temp) temp=res[j-1]+1;
                }
                res[i]=temp;
            }
        }
        
        return res[s.Length-1];
        
    }
    
    private bool CheckValidity(bool[,] valid, string s, int left, int right){
        if(left==right) return true;
        if(left+1==right && s[left]==s[right]) return true;
        if(right-left>1 && s[left]==s[right] && valid[left+1, right-1]) return true;
        return false;
    }
}