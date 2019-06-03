/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void ReorderList(ListNode head) {
        if(head==null || head.next==null || head.next.next==null) return;
        // cut in half
        ListNode fake=new ListNode(0);
        ListNode copy=fake, slow=fake, fast=fake;
        fake.next=head;
        while(fast!=null && fast.next!=null){
            slow=slow.next;
            fast=fast.next.next;
        }
        
        // revert the second part
        ListNode part2=slow.next;
        slow.next=null;
        ListNode part2Head=Revert(part2);
        
        // combine two parts
        while(part2Head!=null){
            ListNode temp=part2Head.next;
            part2Head.next=head.next;
            head.next=part2Head;
            head=head.next.next;
            part2Head=temp;
        }
        head=copy.next;
    }
    
    private ListNode Revert(ListNode head){
        if(head==null || head.next==null) return head;
        ListNode pre=null, next=null;
        while(head!=null && head.next!=null){
            next=head.next;
            head.next=pre;
            pre=head;
            head=next;
        }
        head.next=pre;
        return head;
    }
}