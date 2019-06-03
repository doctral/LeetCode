public class Solution {
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> res=new List<IList<string>>();
        bool[,] valid=new bool[s.Length, s.Length];
        DFS(res, valid, new List<string>(), s, 0);
        return res;
    }
    
    private void DFS(IList<IList<string>> res, bool[,] valid, IList<string> temp, string s, int index){
       if(index==s.Length){
           res.Add(new List<string>(temp));
           return;
       } 
       
       for(int len=1; len<=s.Length-index; len++){
           if(Valid(valid, s, index, index+len-1)){
               temp.Add(s.Substring(index, len));
               DFS(res, valid, temp, s, index+len);
               temp.RemoveAt(temp.Count-1);
           }
       }
    }
    
    private bool Valid(bool[,] valid, string s, int left, int right){
        if(left==right){
            valid[left, right]=true;
            return true;
        }
        if(left+1==right && s[left]==s[right]){
            valid[left, right]=true;
            return true;
        }
        if(right-left>1 && s[left]==s[right] && valid[left+1, right-1]){
            valid[left, right]=true;
            return true;
        }
        return false;
        
    }
}