public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        bool[] res=new bool[s.Length];
        HashSet<string> strs=new HashSet<string>();
        int min=Int32.MaxValue, max=0;
        foreach(string str in wordDict){
            if(str.Length<min) min=str.Length;
            if(str.Length>max) max=str.Length;
            strs.Add(str);
        }
        for(int i=0; i<s.Length; i++){
            if(i+1>=min && i+1<=max && strs.Contains(s.Substring(0, i+1))){
                res[i]=true;
            }
            else{
                for(int j=i-max+1; j<=i-min+1; j++){
                    if(j>0 && res[j-1] && strs.Contains(s.Substring(j, i-j+1))){
                        res[i]=true;
                        break;
                    }
                }
            }
        }
        
        return res[s.Length-1];
    }
}