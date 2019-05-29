public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> parent=new HashSet<string>(wordList);
        int step=1;
        HashSet<string> curr=new HashSet<string>();
        curr.Add(beginWord);
        
        while(curr.Count>0){
            
            HashSet<string> next=new HashSet<string>();
            
            foreach(string w1 in curr){
                foreach(string w2 in parent){
                    if(IsValid(w1, w2)){
                        if(w2==endWord){
                            return step+1;
                        }
                        next.Add(w2);
                    }
                }
            }
            
            foreach(string w in next){
                parent.Remove(w);
            }
            
            step++;
            curr=next;
        }
        
        return 0;
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