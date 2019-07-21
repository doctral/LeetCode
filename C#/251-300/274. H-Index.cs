public class Solution {
    public int HIndex(int[] citations) {
        Array.Sort(citations);
        int n=citations.Length;
        for(int i=0; i<n; i++){
            if(n-i<=citations[i]){
                return n-i;
            }
        }
        return 0;
    }
}