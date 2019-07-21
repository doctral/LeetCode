public class Solution {
    public static HashSet<int> sqs=new HashSet<int>();
    public int NumSquares(int n) {
        if(IsSquare(n)) return 1;
        while(n%4==0) n=n/4;
        if(n%8==7) return 4;
        for(int i=1; i<=n/i; i++){
            if(IsSquare(n-i*i)) return 2;
        }
        return 3;
    }
    
    private bool IsSquare(int num){
        if(sqs.Contains(num)) return true;
        int ss=(int)Math.Sqrt(num);
        if(ss *ss == num ){
            sqs.Add(num);
            return true;
        }
        return false;
    }
}