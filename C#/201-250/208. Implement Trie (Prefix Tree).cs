public class Trie {

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
    public Trie() {
        root=new Node();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        Node curr=root;
        foreach(char ch in word){
            int idx=ch-'a';
            if(curr.Children[idx]==null) curr.Children[idx]=new Node();
            curr=curr.Children[idx];
        }
        curr.IsWord=true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        Node curr=root;
        foreach(char ch in word){
            int idx=ch-'a';
            if(curr.Children[idx]==null) return false;
            curr=curr.Children[idx];
        }
        return curr.IsWord;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        Node curr=root;
        foreach(char ch in prefix){
            int idx=ch-'a';
            if(curr.Children[idx]==null) return false;
            curr=curr.Children[idx];
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */