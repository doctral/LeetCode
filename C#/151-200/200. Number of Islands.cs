public class Solution {
    public int NumIslands(char[][] grid) {
        if(grid.GetLength(0)==0 || grid[0].Length==0) return 0;
        int m=grid.GetLength(0), n=grid[0].Length;
        bool[,] used=new bool[m,n];
        int res=0;
        for(int i=0; i<m; i++){
            for(int j=0; j<n; j++){
                if(grid[i][j]=='1' && !used[i,j]){
                    res++;
                    DFS(i, j, used, grid);
                }
            }
        }
        return res;
    }
    
    private void DFS(int i, int j, bool[,] used, char[][] grid){
        used[i,j]=true;
        if(i-1>=0 && grid[i-1][j]=='1' && !used[i-1,j]) DFS(i-1,j,used,grid);
        if(j-1>=0 && grid[i][j-1]=='1' && !used[i,j-1]) DFS(i,j-1,used,grid);
        if(i+1<grid.GetLength(0) && grid[i+1][j]=='1' && !used[i+1,j]) DFS(i+1,j,used,grid);
        if(j+1<grid[0].Length && grid[i][j+1]=='1' && !used[i,j+1]) DFS(i,j+1,used,grid);
    }
}

