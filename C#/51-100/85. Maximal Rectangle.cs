public class Solution {
    public int MaximalRectangle(char[,] matrix) {
        int m=matrix.GetLength(0), n=matrix.GetLength(1);
        int[][] record=new int[m][];
        for(int i=0; i<m; i++){
            record[i]=new int[n];
            for(int j=0; j<n; j++){
                if(matrix[i,j]=='1'){
                    record[i][j]=(i==0)? 1 : record[i-1][j]+1;
                }
            }
        }
        
        int max=0;
        for(int i=0; i<m; i++){
            max=Math.Max(max, GetMax(record[i]));
        }
        return max;
    }
    
    private int GetMax(int[] row){
        int max=0;
        Stack<int> stack=new Stack<int>();
        for(int i=0; i<=row.Length; i++){
            int curr=i==row.Length? -1 : row[i];
            while(stack.Count>0 && curr<row[stack.Peek()]){
                int h=row[stack.Pop()];
                int w=stack.Count>0? i-stack.Peek()-1 : i;
                max=Math.Max(max, h*w);
            }
            stack.Push(i);
        }
        return max;
    }
}