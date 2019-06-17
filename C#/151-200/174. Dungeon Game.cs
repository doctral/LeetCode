public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        if(dungeon.GetLength(0)==0 || dungeon[0].Length==0) return 1;
        int m=dungeon.GetLength(0), n=dungeon[0].Length;
        int[,] res=new int[m,n];
        res[m-1,n-1]= (1-dungeon[m-1][n-1])>0? 1-dungeon[m-1][n-1] : 1;
        for(int i=m-2; i>=0; i-- ){
            res[i,n-1]= (res[i+1,n-1] - dungeon[i][n-1])>0? res[i+1,n-1] - dungeon[i][n-1] : 1; 
        }
        for(int i=n-2; i>=0; i--){
            res[m-1,i] = (res[m-1,i+1] - dungeon[m-1][i])>0? res[m-1,i+1] - dungeon[m-1][i] : 1;
        }
        
        for(int i=m-2; i>=0; i--){
            for(int j=n-2; j>=0; j--){
                int pre = Math.Min(res[i+1,j], res[i,j+1]);
                res[i,j] = (pre-dungeon[i][j])>0 ? pre-dungeon[i][j] : 1;   
            }
        }
        
        return res[0,0];
    }
}