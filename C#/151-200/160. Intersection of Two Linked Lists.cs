/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        ListNode c1 = headA, c2=headB;
        while(c1!=null && c2!=null){
            c1=c1.next;
            c2=c2.next;
        }
        
        ListNode l = c1!=null? headA: headB;
        ListNode s = c1!=null? headB: headA;
        ListNode c = c1!=null? c1 : c2;
        int diff=0;

        while(c!=null){
            diff++;
            c=c.next;
        }
        
        while(diff>0){
            diff--;
            l=l.next;
        }

        while(l!=null && s!=null){
            if(l==s) return l;
            l=l.next;
            s=s.next;
        }
        
        return null;
    }
}