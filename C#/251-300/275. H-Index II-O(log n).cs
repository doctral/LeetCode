public class Solution {
    public int HIndex(int[] citations) {
        int res=0, left=0, right=citations.Length-1;
        while(left<=right){
            int mid=(left+right)/2;
            if(citations.Length-mid<=citations[mid]){
                res =citations.Length-mid;
                right=mid-1;
            }
            else{
                left=mid+1;
            }
        }
        return res;
    }
}