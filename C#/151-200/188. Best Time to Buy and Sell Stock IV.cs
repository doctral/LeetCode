public class Solution {
    public int MaxProfit(int k, int[] prices) {
        if(prices.Length<2) return 0;
        if(k>=prices.Length/2){
            int res=0;
            for(int i=1; i<prices.Length; i++){
                if(prices[i]>prices[i-1]) res+=prices[i]-prices[i-1];
            }
            return res;
        }
        else{
            
            // res[i,j] = Math.Max(res[i,j-1], res[i-1, x] + prices[j] - prices[x]); 
            // where 0<= x <j. Since prices[j] is constant, we need to find the max of
            // res[i-1,x] - prices[x] to complete the calculation
            
            int[,] res=new int[k+1,prices.Length];
            for(int i=1; i<=k; i++){
                int temp = res[i-1,0] - prices[0];
                for(int j=1; j<prices.Length; j++){
                    if(res[i-1,j-1] - prices[j-1]>temp) temp=res[i-1,j-1] - prices[j-1];
                    res[i,j]=Math.Max(res[i,j-1], temp + prices[j]);
                }
            }
            return res[k,prices.Length-1];
        }
    }
}