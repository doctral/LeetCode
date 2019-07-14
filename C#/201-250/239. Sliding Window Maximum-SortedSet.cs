public class Solution {
    
    public class Dot{
        public int Index {get; set;}
        public int Value {get; set;}
        public Dot(int idx, int v){
            this.Index=idx;
            this.Value=v;
        }
    }
    
    public class ComparerValue : IComparer<Dot>{
        public int Compare(Dot a, Dot b){
            if(a.Value==b.Value){
                return a.Index-b.Index;
            }
            return a.Value - b.Value;
        }
    }
    
    public class ComparerIndex: IComparer<Dot>{
        public int Compare(Dot a, Dot b){
            return a.Index - b.Index;
        }
    }
    
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if(nums.Length==0 || k<1) return new int[0];
        int[] res=new int[nums.Length-k+1];
        SortedSet<Dot> window=new SortedSet<Dot>(new ComparerValue());
        SortedSet<Dot> indexWindow=new SortedSet<Dot>(new ComparerIndex());
        
        int max=int.MaxValue, index=0;
        for(int i=0; i<nums.Length; i++){
            Dot dot=new Dot(i, nums[i]);
            window.Add(dot);
            indexWindow.Add(dot);
            if(i<k-1) continue;
            
            res[index]=window.Max.Value;
            index++;
            
            Dot left = indexWindow.Min;
            indexWindow.Remove(left);
            window.Remove(left);
        }
        
        return res;
    }
    
}