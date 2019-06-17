public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        StringBuilder sb=new StringBuilder();
        
        int flag=1;
        if(numerator>0 && denominator<0 || numerator<0 && denominator>0) flag=-1;
        long num=Math.Abs((long)numerator);
        long den=Math.Abs((long)denominator);
        long res = num/den;
        long rem=num%den;
        if(flag==-1) sb.Append("-");
        sb.Append(res);
        
        if(rem==0) return sb.ToString();
        
        sb.Append('.');
        
        Dictionary<long, int> map=new Dictionary<long, int>();
        IList<int> list = new List<int>();
        int index=0;
        while(rem!=0){
            rem*=10;
            if(map.ContainsKey(rem)) break;
            map[rem]=index;
            list.Add( (int)(rem/den) );
            rem=rem%den;
            index++;
        }
        if(rem==0){
            foreach(int n in list){
                sb.Append(n);
            }
        }
        else{
            int recIndex=map[rem];
            for(int i=0; i<recIndex; i++){
                sb.Append(list[i]);
            }
            sb.Append('(');
            for(int i=recIndex; i<list.Count; i++){
                sb.Append(list[i]);
            }
            sb.Append(')');
        }
        return sb.ToString();
    }
}