public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> res=new List<IList<int>>();
        if(numRows==0) return res;
        res.Add(new List<int>(new int[]{1}));
        int index=2;
        while(index<=numRows){
            IList<int> pre=res[res.Count-1];
            IList<int> curr=new List<int>();
            for(int i=0; i<index; i++){
                int num1= (i-1)>=0? pre[i-1] : 0;
                int num2= i<(index-1)? pre[i] : 0;
                curr.Add(num1+num2);
            }
            res.Add(curr);
            index++;
        }
        
        return res;
    }
}