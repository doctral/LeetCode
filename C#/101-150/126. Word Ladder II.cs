public class Solution {
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        IList<IList<string>> res=new List<IList<string>>();
        HashSet<string> parent=new HashSet<string>(wordList);
        IList<HashSet<string>> lists=GetAllLists(beginWord, endWord, parent);
        if(lists.Count==0) return res;
        IList<string> temp=new List<string>();
        temp.Add(beginWord);
        DFS(lists, res, temp, 1);
        return res;
    }
    
    private void DFS(IList<HashSet<string>> lists, IList<IList<string>> res, IList<string> temp, int index){
        if(index==lists.Count){
            res.Add(new List<string>(temp));
            return;
        }
        
        foreach(string str in lists[index]){
            if(IsValid(temp[temp.Count-1], str)){
                temp.Add(str);
                DFS(lists, res, temp, index+1);
                temp.RemoveAt(temp.Count-1);
            }
        }
    }
    
    private IList<HashSet<string>> GetAllLists(string begin ,string end, HashSet<string> parent){
        IList<HashSet<string>> res=new List<HashSet<string>>();
        HashSet<string> curr=new HashSet<string>();
        curr.Add(begin);
    
        while(curr.Count>0){
            res.Add(new HashSet<string>(curr));
            HashSet<string> next=new HashSet<string>();
            foreach(string w1 in curr){
                foreach(string w2 in parent){
                    if(IsValid(w1,w2)){
                        if(w2==end) {
                            res.Add(new HashSet<string>(new string[]{end}));
                            return res;
                        }
                        next.Add(w2);
                    }
                }
            }
            
            foreach(string str in next){
                parent.Remove(str);
            }
            
            curr=next;
        }
        
        return new List<HashSet<string>>();
    }
    
    private bool IsValid(string w1, string w2){
        int diff=0; 
        for(int i=0; i<w1.Length; i++){
            if(w1[i]!=w2[i]) diff++;
            if(diff>1) return false;
        }
        return diff==1;
    }
}