public class Solution {
    public int CountPrimes(int n) {
        bool[] notPrimes=new bool[n];
        for(int i=2; i<=Math.Sqrt(n); i++){
            if(!notPrimes[i]){
                for(int j=i*i; j<n; j+=i){
                    notPrimes[j]=true;
                }
            }
        }
        
        int count=0;
        for(int i=2; i<n; i++){
            if(!notPrimes[i]) count++;
        }
        return count;
    }
}