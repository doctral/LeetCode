public class Solution {
    public void Solve(char[][] board) {
        if(board.GetLength(0)==0 || board[0].Length==0 ) return;
        int m=board.GetLength(0), n=board[0].Length;
        Queue<P> q=new Queue<P>();
        
        for(int i=0; i<n; i++){
            if(board[0][i]=='O') q.Enqueue(new P(0, i));
            if(board[m-1][i]=='O') q.Enqueue(new P(m-1, i));
        }
        
        for(int i=1; i<m-1; i++){
            if(board[i][0]=='O') q.Enqueue(new P(i, 0));
            if(board[i][n-1]=='O') q.Enqueue(new P(i, n-1));
        }
        
        while(q.Count>0){
            P p=q.Dequeue();
            if(board[p.X][p.Y]=='*') continue;
            
            board[p.X][p.Y]='*';
            
            if(p.X-1>=0 && board[p.X-1][p.Y]=='O') q.Enqueue(new P(p.X-1, p.Y));
            if(p.X+1<m && board[p.X+1][p.Y]=='O') q.Enqueue(new P(p.X+1, p.Y));
            if(p.Y-1>=0 && board[p.X][p.Y-1]=='O') q.Enqueue(new P(p.X, p.Y-1));
            if(p.Y+1<n && board[p.X][p.Y+1]=='O') q.Enqueue(new P(p.X, p.Y+1));
        }
        
        for(int i=0; i<m; i++){
            for(int j=0; j<n; j++){
                if(board[i][j]!='X'){
                    board[i][j]=board[i][j]=='O'? 'X' : 'O';

                }
            }
        }
    }
}

public class P{
    public int X;
    public int Y;
    public P(int x, int y){
        X=x;
        Y=y;
    }
}