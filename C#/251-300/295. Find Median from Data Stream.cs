public class MedianFinder {
    public class MyComparer: IComparer<int[]>{
        public int Compare(int[] a, int[] b){
            if(a[0]==b[0]){
                return a[1]-b[1];
            }
            else{
                return a[0]-b[0];
            }
        }
    }
    
    private SortedSet<int[]> low;
    private SortedSet<int[]> high;
    private int Count;
    
    /** initialize your data structure here. */
    public MedianFinder() {
        low=new SortedSet<int[]>(new MyComparer());
        high=new SortedSet<int[]>(new MyComparer());
        Count=0;
    }
    
    public void AddNum(int num) {
        int[] item=new int[]{num, ++Count};
        if(low.Count==high.Count){
            if(low.Count==0 || num<=low.Max[0]){
                low.Add(item);
            }
            else{
                high.Add(item);
                low.Add(high.Min);
                high.Remove(high.Min);
            }
        }
        else{
            if(num<=low.Max[0]){
                low.Add(item);
                high.Add(low.Max);
                low.Remove(low.Max);
            }
            else{
                high.Add(item);
            }
        }
    }
    
    public double FindMedian() {
        if(Count==0) return 0;
        if(Count%2==1) return low.Max[0];
        return low.Max[0]*0.5 + high.Min[0]*0.5;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */