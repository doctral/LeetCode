public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        if(matrix.GetLength(0)==0 || matrix.GetLength(1)==0 ) return false;
        int m=matrix.GetLength(0), n=matrix.GetLength(1);
        if(matrix[0,0]>target || matrix[m-1,n-1]<target) return false;
        int right=n-1;
        for(int i=0; i<n; i++){
            if(matrix[0,i]>target){
                right=i;
                break;
            }
        }
        
        for(int i=0; i<m; i++){
            if(matrix[i, 0]>target) break;
            if(BinarySearch(matrix, i, right, target)) return true;
        }
        
        return false;
    }
    
    private bool BinarySearch(int[,] matrix, int i, int j, int target){
        int left=0, right=j;
        while(left<=right){
            int mid=(left+right)/2;
            if(matrix[i, mid]==target) return true;
            if(matrix[i,mid]<target){
                left=mid+1;
            }
            else {
                right=mid-1;
            }
        }
        return false;
    }
}