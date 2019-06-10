public class MinStack {

    /** initialize your data structure here. */
    int[] stack;
    int index, min;
    public MinStack() {
        stack=new int[128];
        index=-1;
        min=Int32.MaxValue;
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
        
        if(min>=x){
            stack[index++]=min;
            min=x;
        }
        stack[index]=x;
    }
    
    public void Pop() {
        if(stack[index--]==min){
            min=stack[index--];
        }
    }
    
    public int Top() {
        return stack[index];
    }
    
    public int GetMin() {
        return min;
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