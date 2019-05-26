public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        
        for(int i=1; i<triangle.Count; i++){
            for(int j=0; j<triangle[i].Count; j++){
                int num1=(j-1)>=0? triangle[i][j]+triangle[i-1][j-1] : Int32.MaxValue;
                int num2=j<triangle[i-1].Count? triangle[i][j]+triangle[i-1][j] : Int32.MaxValue;
                triangle[i][j]=Math.Min(num1, num2);
            }
        }
        
        int res=Int32.MaxValue;
        for(int i=0; i<triangle[triangle.Count-1].Count; i++){
            if(triangle[triangle.Count-1][i]<res) res=triangle[triangle.Count-1][i];
        }
        
        return res;
    }
}