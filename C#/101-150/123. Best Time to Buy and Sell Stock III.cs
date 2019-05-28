public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length<2) return 0;
        int[] left_max=new int[prices.Length];
        int left_min=prices[0];
        for(int i=1; i<prices.Length; i++){
            left_max[i]=(prices[i]-left_min>left_max[i-1])? prices[i]-left_min : left_max[i-1];
            if(prices[i]<left_min) left_min=prices[i];
        }
        
        int right=prices[prices.Length-1];
        int[] right_max=new int[prices.Length];
        for(int i=prices.Length-2; i>=0; i--){
            right_max[i]=(right-prices[i]>right_max[i+1])? right-prices[i] : right_max[i+1];
            if(prices[i]>right) right=prices[i];
        }
        
        int res=0;
        for(int i=0; i<prices.Length; i++){
            if(i==0){
              if(right_max[i]>res) res=right_max[i];  
            } 
            else if(i==prices.Length-1) 
            {
              if(left_max[i]>res) res=left_max[i];   
            }
            else if(left_max[i]+right_max[i+1]>res){
              res=left_max[i]+right_max[i+1];   
            }  
        }
        
        return res;
    }
}