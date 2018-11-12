public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int max=0;
        Stack<int> stack=new Stack<int>();
        for(int i=0; i<=heights.Length; i++){
            int currHeight= (i==heights.Length)? -1 : heights[i];
            while(stack.Count>0 && currHeight<heights[stack.Peek()]){
                int height=heights[stack.Pop()];
                int width=(stack.Count>0)? (i-stack.Peek()-1) : i;
                max=Math.Max(max, height * width);
            }
            stack.Push(i);
        }
        return max;
    }
}