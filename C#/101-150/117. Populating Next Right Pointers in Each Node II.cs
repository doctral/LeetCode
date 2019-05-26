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
        if(root==null) return root;
        Node copy=root, parent=root, curr=null, currCopy=null;
        
        while(true){
            curr=null;
            currCopy=null;
            
            while(parent!=null){
                if(parent.left!=null){
                    curr=parent.left;
                    currCopy=parent.left;
                    break;
                }
                if(parent.right!=null){
                    curr=parent.right;
                    currCopy=parent.right;
                    break;
                }
                parent=parent.next;
            }
            
            if(curr==null || parent==null) break;
            
            while(parent!=null){
                if(parent.left!=null && parent.left!=curr){
                    curr.next=parent.left;
                    curr=curr.next;
                }
                if(parent.right!=null && parent.right!=curr){
                    curr.next=parent.right;
                    curr=curr.next;
                }
                parent=parent.next;
            }
            
            parent=currCopy;
        }
        
        return copy;
    }
}