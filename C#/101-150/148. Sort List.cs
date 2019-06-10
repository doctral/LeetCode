/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode SortList(ListNode head) {
        if(head==null || head.next==null) return head;
        ListNode slow=head;
        ListNode fast=head;
        while(fast.next!=null && fast.next.next!=null){
            slow=slow.next;
            fast=fast.next.next;
        }
        fast=slow.next;
        slow.next=null;
        return Merge(SortList(head), SortList(fast));
    }
    
    private ListNode Merge(ListNode node1, ListNode node2){
        ListNode fake=new ListNode(0);
        ListNode curr=fake;
        while(node1!=null && node2!=null){
            if(node1.val<node2.val){
                curr.next=node1;
                node1=node1.next;
            }
            else{
                curr.next=node2;
                node2=node2.next;
            }
            curr=curr.next;
            curr.next=null;
        }
        
        curr.next= (node1!=null)? node1 : node2;
        return fake.next;
    }
}