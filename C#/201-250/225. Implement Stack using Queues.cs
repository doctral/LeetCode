public class MyStack {

    Queue<int> inq;
    Queue<int> outq;
    /** Initialize your data structure here. */
    public MyStack() {
        inq=new Queue<int>();
        outq=new Queue<int>();
    }
    
    /** Push element x onto stack. */
    public void Push(int x) {
        while(inq.Count>0){
            outq.Enqueue(inq.Dequeue());
        }
        inq.Enqueue(x);
        while(outq.Count>0){
            inq.Enqueue(outq.Dequeue());
        }
    }
    
    /** Removes the element on top of the stack and returns that element. */
    public int Pop() {
        return inq.Dequeue();
    }
    
    /** Get the top element. */
    public int Top() {
        return inq.Peek();
    }
    
    /** Returns whether the stack is empty. */
    public bool Empty() {
        return inq.Count==0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */