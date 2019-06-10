public class MinStack {

    /** initialize your data structure here. */
    Stack<int> mins;
    Stack<int> stack;
    
    public MinStack() {
        mins=new Stack<int>();
        stack=new Stack<int>();
    }
    
    public void Push(int x) {
        stack.Push(x);
        if(mins.Count>0){
            mins.Push(x>mins.Peek()? mins.Peek() : x);
        }
        else{
            mins.Push(x);
        }
    }
    
    public void Pop() {
        stack.Pop();
        mins.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return mins.Peek();
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