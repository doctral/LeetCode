/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        if(head==null || head.next==null) return head;
        ListNode pre=null, temp=null;
        while(head.next!=null){
            temp=head.next;
            head.next=pre;
            pre=head;
            head=temp;
        }
        head.next=pre;
        return head;
    }
}