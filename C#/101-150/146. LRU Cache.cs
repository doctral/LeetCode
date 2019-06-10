public class LRUCache {
    
    public class Node{
        public Node pre, next;
        public int key, value;
        public Node(int k, int v){
            this.key=k;
            this.value=v;
        }
        public Node(){}
    }
    
    Node head, tail;
    int capacity, count;
    Dictionary<int, Node> map;
    
    public LRUCache(int capacity) {
        map=new Dictionary<int, Node>();
        this.capacity=capacity;
        count=0;
        head=new Node();
        tail=new Node();
        head.next=tail;
        tail.pre=head;
    }
    
    public int Get(int key) {
        if(map.ContainsKey(key)){
            Node target = map[key];
            Remove(target);
            Add(target);
            return target.value;
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        if(map.ContainsKey(key)){
            Node target = map[key];
            Remove(target);
            target.value=value;
            Add(target);
            map[key]=target;
        }
        else{
            Node tar=new Node(key, value);
            map[key]=tar;
            if(count==capacity){
                Node target = RemoveTail();
                count--;
                map.Remove(target.key);
            }
            Add(tar);
            count++;
        }
    }
    
    private void Add(Node node){
        node.next=head.next;
        head.next.pre=node;
        node.pre=head;
        head.next=node;
    }
    
    private void Remove(Node node){        
        node.pre.next=node.next;
        node.next.pre=node.pre;
        node.next=null;
        node.pre=null;
    }
    
    private Node RemoveTail(){
        Node target = tail.pre;
        Remove(target);
        return target;
    }
}



/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */