/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node(){}
    public Node(int _val,Node _left,Node _right,Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
}
*/
public class Solution {
    public Node Connect(Node root) {
        if(root==null || root.left==null) return root;
        
        Node copy=root, parent=root, curr=null, currCopy=null;
        
        while(parent.left!=null){
            curr=parent.left;
            currCopy=parent.left;
            
            while(parent!=null){
                curr.next=parent.right;
                curr=curr.next;
                parent=parent.next;
                if(parent!=null) {
                    curr.next=parent.left;
                    curr=curr.next;
                }
            }
            
            parent=currCopy;
        }
        return copy;
    }
}