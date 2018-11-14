/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        ListNode fake=new ListNode(0);
        fake.next=head;
        ListNode slow=fake, fast=fake;
        while(fast.next!=null && fast.next.val<x){
            slow=slow.next;
            fast=fast.next;
        }
        while(fast!=null && fast.next!=null){
            if(fast.next.val<x){
                ListNode temp=fast.next;
                fast.next=fast.next.next;
                temp.next=slow.next;
                slow.next=temp;
                slow=slow.next;
            }
            else{
                fast=fast.next;
            }
            
        }
        return fake.next; 
    }
}