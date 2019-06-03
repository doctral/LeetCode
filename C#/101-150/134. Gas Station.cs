public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int res=-1;
        for(int i=0; i<gas.Length && res==-1; i++){
            if(cost[i]<=gas[i]){
                int total=gas[i]-cost[i], curr=i+1;
                while(true){
                    if(curr==gas.Length) curr=0;
                    if(curr==i) {
                        res=i;
                        break;
                    }
                    total+=gas[curr]-cost[curr];
                    if(total<0) break;
                    curr++;
                }
            }
        }
        return res;
    }
}