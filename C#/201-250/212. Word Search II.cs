public class Solution {
    public IList<string> FindWords(char[][] board, string[] words) {
        IList<string> res=new List<string>();
        if(board.GetLength(0)==0 || board[0].Length==0 || words.Length==0 ) return res;
        
        Trie trie=new Trie();
        foreach(string str in words){
            trie.Add(str);
        }
        
        HashSet<string> strs=new HashSet<string>();
        int m=board.GetLength(0), n=board[0].Length;
        bool[,] used=new bool[m,n];
        
        for(int i=0; i<m; i++){
            for(int j=0; j<n; j++){
                FindWords(strs, board, used, i, j, trie, trie.Root(), new StringBuilder());
            }
        }
        
        foreach(string str in strs){
            res.Add(str);
        }
        
        return res;
    }
    
    private void FindWords(HashSet<string> strs, char[][] board, bool[,] used, int i, int j, Trie trie, Node curr, StringBuilder sb){
        if(!trie.IsValid(curr, board[i][j])) return;
        used[i,j]=true;
        sb.Append(board[i][j]);
        curr=curr.Children[board[i][j]-'a'];
        if(curr.IsWord) strs.Add(sb.ToString());
        
        if(i-1>=0 && !used[i-1,j]) FindWords(strs, board, used, i-1, j, trie, curr, sb);
        if(i+1<board.GetLength(0) && !used[i+1,j]) FindWords(strs, board, used, i+1, j, trie, curr, sb);
        if(j-1>=0 && !used[i,j-1]) FindWords(strs, board, used, i, j-1, trie, curr, sb);
        if(j+1<board[0].Length && !used[i,j+1]) FindWords(strs, board, used, i, j+1, trie, curr, sb);
        
        used[i,j]=false;
        sb.Remove(sb.Length-1, 1);
    }
}

public class Node{
    public bool IsWord=false;
    public Node[] Children=new Node[26];
}

public class Trie{    
    Node root;
    
    public Trie(){
        root=new Node();
    }
    
    public void Add(string word){
        Node curr=root;
        foreach(char ch in word){
            int idx=ch-'a';
            if(curr.Children[idx]==null) curr.Children[idx]=new Node();
            curr=curr.Children[idx];
        }
        curr.IsWord=true;
    }
    
    public Node Root(){
        return this.root;
    }
    
    public bool IsValid(Node curr, char ch){
        return curr.Children[ch-'a']!=null;
    }
    
}