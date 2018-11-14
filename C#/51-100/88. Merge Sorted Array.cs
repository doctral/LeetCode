public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        if(n==0) return;
        int idx1=m-1, idx2=n-1, curr=m+n-1;
        while(curr>=0){
            if(idx1<0){
                nums1[curr]=nums2[idx2];
                idx2--;
            }
            else if(idx2<0){
                nums1[curr]=nums1[idx1];
                idx1--;
            }
            else{
                nums1[curr]= nums1[idx1]<nums2[idx2]? nums2[idx2--]: nums1[idx1--];
            }
            curr--;
        }
    }
}