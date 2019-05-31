public class Solution {
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> res=new List<IList<string>>();
        DFS(res, new List<string>(), s, 0);
        return res;
    }
    
    private void DFS(IList<IList<string>> res, IList<string> temp, string str, int index){
        if(index==str.Length){
            res.Add(new List<string>(temp));
            return;
        }
        
        for(int i=1; i<str.Length-index+1; i++){
            if(IsPalindrome(str.Substring(index, i))){
                temp.Add(str.Substring(index, i));
                DFS(res, temp, str, index+i);
                temp.RemoveAt(temp.Count-1);
            }
        }
    }
    
    private bool IsPalindrome(string str){
        for(int i=0, j=str.Length-1; i<j; i++, j--){
            if(str[i]!=str[j]) return false;
        }
        return true;
    }
}