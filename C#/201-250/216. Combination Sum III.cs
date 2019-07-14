public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        IList<IList<int>> res=new List<IList<int>>();
        Backtracking(res, new List<int>(), k, n, 1);
        return res;
    }
    
    private void Backtracking(IList<IList<int>> res, IList<int> temp, int k, int n, int start){
        if(temp.Count==k && n==0){
            res.Add(new List<int>(temp));
            return;
        }
        
        for(int i=start; i<=9; i++){
            if(i>n) break;
            temp.Add(i);
            Backtracking(res, temp, k, n-i, i+1);
            temp.RemoveAt(temp.Count-1);
        }
    }
}