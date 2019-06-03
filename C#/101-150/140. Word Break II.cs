public class Solution {
    private int min=Int32.MaxValue, max=0;
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        
        HashSet<string> strs=new HashSet<string>();
        foreach(string str in wordDict){
            if(str.Length<min) min=str.Length;
            if(str.Length>max) max=str.Length;
            strs.Add(str);
        }
        bool[] valid=new bool[s.Length];
        
        for(int i=0; i<s.Length; i++){
            if(i+1>=min && i+1<=max && strs.Contains(s.Substring(0, i+1))){
                valid[i]=true;
            }
            else{
                for(int j=i-max+1; j<=i-min+1; j++){
                    if(j>0 && valid[j-1] && strs.Contains(s.Substring(j, i-j+1))){
                        valid[i]=true;
                        break;
                    }
                }
            }
        }
        
        IList<string> res=new List<string>();
        if(!valid[s.Length-1]) return res;
        
        DFS(res, new List<string>(), strs, s, 0);
        
        return res;
    }
    
    private void DFS(IList<string> res, IList<string> temp, HashSet<string> strs, string s, int index){
        if(index==s.Length){
            StringBuilder sb=new StringBuilder();
            for(int i=0; i<temp.Count; i++){
                sb.Append(temp[i]);
                if(i!=temp.Count-1) sb.Append(' ');
            }
            res.Add(sb.ToString());
            return;
        }
        
        for(int i=min; i<=max; i++){
            if(index+i-1<s.Length && strs.Contains(s.Substring(index, i))){
                temp.Add(s.Substring(index, i));
                DFS(res, temp, strs, s, index+i);
                temp.RemoveAt(temp.Count-1);
            }
        }
    }
}