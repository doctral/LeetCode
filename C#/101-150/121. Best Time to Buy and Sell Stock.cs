public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length<2) return 0;
        int min_left=prices[0];
        int res=0;
        for(int i=1; i<prices.Length; i++){
            if(prices[i]-min_left>res) res=prices[i]-min_left;
            if(prices[i]<min_left) min_left=prices[i];
        }
        return res;
    }
}