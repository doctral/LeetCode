public class Solution {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        int area1=(C-A)*(D-B), area2 = (G-E)*(H-F);
        int left=Math.Max(A,E);
        int right = Math.Max(Math.Min(C,G), left);
        int bottom = Math.Max(B,F);
        int top = Math.Max(Math.Min(D,H), bottom);
        
        return area1+area2-(right-left)*(top-bottom);
    }
}