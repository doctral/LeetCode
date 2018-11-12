public class Solution {
    public int LargestRectangleArea(int[] heights) {
        return FindMax(heights, 0, heights.Length-1);
    }
    
    private int FindMax(int[] heights, int left, int right){
        if(left>right) return 0;
        if(left==right) return heights[left];
        
        // find the minIndex and check if sorted
        int minIndex=left;
        bool sorted=true;
        for(int i=left+1; i<=right; i++){
            if(heights[i-1]>heights[i]) sorted=false;
            if(heights[i]<heights[minIndex]) minIndex=i;
        }
        
        // if sorted, then get the max and return
        if(sorted){
            int max=0;
            for(int i=right; i>=left; i--){
                max=Math.Max(max, heights[i]*(right-i+1));
            }
            return max;
        }
        
        // otherwise, get the max from left, right and mid recursively
        int leftMax=FindMax(heights, left, minIndex-1);
        int rightMax=FindMax(heights, minIndex+1, right);
        int midMax=heights[minIndex]*(right-left+1);
        return Math.Max(Math.Max(leftMax, rightMax), midMax);
        
    }
}