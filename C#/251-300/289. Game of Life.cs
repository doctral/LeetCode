public class Solution {
    public void GameOfLife(int[][] board) {
       if(board.GetLength(0)==0 || board[0].Length==0) return;
        int m=board.GetLength(0), n=board[0].Length;
        for(int i=0; i<m; i++){
            for(int j=0; j<n; j++){
                int c=CountLive(board, m, n, i, j);
                if(board[i][j]==0){
                    if(c==3) board[i][j]=-1;
                }
                else{
                    if(c<2 || c>3) board[i][j]=2;
                }
            }
        }
        
        for(int i=0; i<m; i++){
            for(int j=0; j<n; j++){
                if(board[i][j]==-1) board[i][j]=1;
                if(board[i][j]==2) board[i][j]=0;
            }
        }
    }
    
    private int CountLive(int[][] board, int m, int n, int i, int j){
        int count=0;
        if(i-1>=0 && board[i-1][j]>=1) count++;
        if(i-1>=0 && j-1>=0 && board[i-1][j-1]>=1) count++;
        if(i-1>=0 && j+1<n && board[i-1][j+1]>=1) count++;
        if(j-1>=0 && board[i][j-1]>=1) count++;
        if(j+1<n && board[i][j+1]>=1) count++;
        if(i+1<m && board[i+1][j]>=1) count++;
        if(i+1<m && j-1>=0 && board[i+1][j-1]>=1) count++;
        if(i+1<m && j+1<n && board[i+1][j+1]>=1) count++;
        return count;
    }
    
}