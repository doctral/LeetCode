public class Solution {
    public int MaximalSquare(char[][] matrix) {
        if(matrix.GetLength(0)==0 || matrix[0].Length==0 ) return 0;
        int m=matrix.GetLength(0), n=matrix[0].Length;
        int[,] res=new int[m,n];
        int max=0;
        for(int i=0; i<m; i++){
            if(matrix[i][0]=='1'){
              res[i,0]=1;
                max=1;
            } 
        }
        
        for(int i=0; i<n; i++){
            if(matrix[0][i]=='1'){
                res[0,i]=1;
                max=1;
            }
        }
        
        for(int i=1; i<m; i++){
            for(int j=1; j<n; j++){
                if(matrix[i][j]=='1'){
                    if(res[i-1,j]>0 && res[i,j-1]>0 && res[i-1,j-1]>0){
                        res[i,j]=Math.Min(res[i-1,j], Math.Min(res[i,j-1], res[i-1,j-1]))+1;
                        if(res[i,j]>max)  max=res[i,j];
                    }
                    else{
                        res[i,j]=1;
                    }
                    
                }
            }
        }
        
        return max*max;
    }
}