public class MinStack {

    /** initialize your data structure here. */
    int[] stack;
    int index;
    public MinStack() {
        stack=new int[128];
        index=-1;
    }
    
    public void Push(int x) {
        index++;
        
        if(index+2>=stack.Length){
            int[] arr=new int[stack.Length*2];
            for(int i=0; i<stack.Length; i++){
                arr[i]=stack[i];
            }
            stack=arr;
        }
        
        if(index==0){
            stack[index++]=x;
            stack[index]=x;
        }
        else{
            stack[index]=Math.Min(x, stack[index-2]);
            stack[++index]=x;
        }
    }
    
    public void Pop() {
        index-=2;
    }
    
    public int Top() {
        return stack[index];
    }
    
    public int GetMin() {
        return stack[index-1];
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */