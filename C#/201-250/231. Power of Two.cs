public class Solution {
    public bool IsPowerOfTwo(int n) {
        if(n<1) return false;
        if(n<3) return true;
        if(n%2 != 0) return false;
        return IsPowerOfTwo(n/2);
    }
}