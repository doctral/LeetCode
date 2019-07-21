public class Solution {
    public IList<string> AddOperators(string num, int target) {
        IList<string> res=new List<string>();
        char[] chs=new char[num.Length*2];
        long currVal=0;
        for(int i=0; i<num.Length; i++){
            currVal=currVal*10+(num[i]-'0');
            chs[i]=num[i];
            DFS(res, num, chs, i+1, i+1, 0, currVal, target);
            if(currVal==0) break;
        }
        return res;
    }
    
    private void DFS(IList<string> res, string num, char[] arr, int charIndex, int arrIndex, long baseVal, long currVal, int target){
        if(charIndex==num.Length){
            if(baseVal+currVal==target){
                res.Add(new string(arr, 0, arrIndex));
            }
            return;
        }
        
        long nextVal=0;
        int signIndex=arrIndex;
        for(int i=charIndex; i<num.Length; i++){
            nextVal=nextVal*10+(num[i]-'0');
            arrIndex++;
            arr[arrIndex]=num[i];
            
            arr[signIndex]='+';
            DFS(res, num, arr, i+1, arrIndex+1, baseVal+currVal, nextVal, target);
            
            arr[signIndex]='-';
            DFS(res, num, arr, i+1, arrIndex+1, baseVal+currVal, -nextVal, target);
            
            arr[signIndex]='*';
            DFS(res, num, arr, i+1, arrIndex+1, baseVal, currVal*nextVal, target);
            
            if(nextVal==0) return;
        }
    }
}