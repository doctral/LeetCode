/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(){}
    public Node(int _val,Node _next,Node _random) {
        val = _val;
        next = _next;
        random = _random;
}
*/
public class Solution {
    Dictionary<Node, Node> map=new Dictionary<Node,Node>();
    public Node CopyRandomList(Node head) {
        if(head==null) return null;
        map[head]=new Node(head.val, null, null);
        map[head].next=CopyRandomList(head.next);
        if(head.random!=null){
            map[head].random=map[head.random];
        }
        return map[head];
    }
}