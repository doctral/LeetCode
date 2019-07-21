/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int res=1, left=1, right=n;
        while(left<=right){
            int mid=left+(right-left)/2;
            if(!IsBadVersion(mid)){
                left=mid+1;
            }
            else{
                res=mid;
                right=mid-1;
            }
        }
        return res;
    }
}