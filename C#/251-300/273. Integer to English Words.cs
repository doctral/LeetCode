public class Solution {
    string[] singles=new string[]{"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
    string[] tens=new string[]{"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
    string[] bigger=new string[]{"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
    
    public string NumberToWords(int num) {
        if(num==0) return "Zero";
        StringBuilder sb=new StringBuilder();
        int temp=num/1000000000;
        if(temp>0){
            sb.Append(ReadThousandNum(temp) +" Billion");
            if(num%1000000000==0) return sb.ToString();
            sb.Append(" ");
            num=num%1000000000;
        }
        temp=num/1000000;
        if(temp>0){
            sb.Append(ReadThousandNum(temp)+" Million");
            if(num%1000000==0) return sb.ToString();
            sb.Append(" ");
            num=num%1000000;
        }
        temp=num/1000;
        if(temp>0){
            sb.Append(ReadThousandNum(temp)+" Thousand");
            if(num%1000==0) return sb.ToString();
            sb.Append(" ");
            num=num%1000;
        }
        sb.Append(ReadThousandNum(num));
        return sb.ToString();
    }
    
    private string ReadThousandNum(int num){        
        StringBuilder sb=new StringBuilder();
        int h = num/100;
        if(h>=1)
        {
          sb.Append(singles[h] + " Hundred");
          if(num%100==0) return sb.ToString();
          sb.Append(" ");  
        } 
        num=num%100;
        int t=num/10;
        if(t>1){
            sb.Append(bigger[t]);
            int d = num%10;
            if(d>0) sb.Append(" "+singles[d]);
        }
        else if(t==1){
            int d=num%10;
            sb.Append(tens[d]);
        }
        else{
            sb.Append(singles[num%10]);
        }
        
        return sb.ToString();
    }
}