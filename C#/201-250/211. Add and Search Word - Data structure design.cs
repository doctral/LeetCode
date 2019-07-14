public class WordDictionary {

    internal class Node{
        internal bool IsWord;
        internal Node[] Children;
        internal Node(){
            Children=new Node[26];
            IsWord=false;
        }
    }
    
    Node root;
    
    /** Initialize your data structure here. */
    public WordDictionary() {
        root=new Node();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        Node curr=root;
        foreach(char ch in word){
            int idx=ch-'a';
            if(curr.Children[idx]==null) curr.Children[idx]=new Node();
            curr=curr.Children[idx];
        }
        curr.IsWord=true;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        Node curr=root;
        return Search(word, curr, 0);
    }
    
    private bool Search(string word, Node curr, int idx){
        if(idx==word.Length) return curr.IsWord;
        
        if(word[idx]!='.'){
            int index=word[idx]-'a';
            if(curr.Children[index]==null) return false;
            return Search(word, curr.Children[index], idx+1);
        }
        else{
            for(int i=0; i<26; i++){
                if(curr.Children[i]!=null && Search(word, curr.Children[i], idx+1)){
                    return true;
                }
            }
            return false;
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */