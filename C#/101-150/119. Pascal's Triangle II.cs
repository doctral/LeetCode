public class Solution {
    public IList<int> GetRow(int rowIndex) {
        IList<int> res=new List<int>();
        res.Add(1);
        int index=1;
        while(index<=rowIndex){
            IList<int> curr=new List<int>();
            for(int i=0; i<=index; i++){
                if(i==0 || i==index){
                    curr.Add(1);
                }
                else{
                    curr.Add(res[i]+res[i-1]);
                }
            }
            res=curr;
            index++;
        }
        return res;
    }
}