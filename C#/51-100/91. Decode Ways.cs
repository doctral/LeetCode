public class Solution {
    public int NumDecodings(string s) {
        if(s[0]=='0') return 0;
        int[] res=new int[s.Length];
        res[0]=1;
        for(int i=1; i<s.Length; i++){
            if(s[i]=='0'){
                if(s[i-1]!='1' && s[i-1]!='2') return 0;
                if(i>1){
                    res[i]=res[i-2];
                }
                else{
                    res[i]=1;
                }
            }
            else if(s[i-1]=='1' || (s[i-1]=='2' && s[i]>='1' && s[i]<'7')){
                if(i==1){
                    res[i]=2;
                }
                else{
                    res[i]=res[i-1]+res[i-2];
                }
            }
            else{
                res[i]=res[i-1];
            }
        }
        return res[res.Length-1];
    }
}