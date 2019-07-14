public class Solution {
    Dictionary<string, IList<int>> map=new Dictionary<string, IList<int>>();
    
    public IList<int> DiffWaysToCompute(string input) {
        if(map.ContainsKey(input)) return map[input];
        map[input]=new List<int>();
        
        for(int i=0; i<input.Length; i++){
            char ch=input[i];
            if(ch=='+' || ch=='-' || ch=='*'){
                string left=input.Substring(0,i);
                string right=input.Substring(i+1);
                IList<int> left_nums=DiffWaysToCompute(left);
                IList<int> right_nums=DiffWaysToCompute(right);
                foreach(int l in left_nums){
                    foreach(int r in right_nums){
                        if(ch=='+'){
                            map[input].Add(l+r);
                        }
                        else if(ch=='-'){
                            map[input].Add(l-r);
                        }
                        else{
                            map[input].Add(l*r);
                        }
                    }
                }
            }
        }
        
        if(map[input].Count==0) map[input].Add(int.Parse(input));
        return map[input];
    }
}