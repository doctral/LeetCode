/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        ListNode fake=new ListNode(0);
        fake.next=head;
        ListNode slow=fake, fast=fake;
        int index=0;
        while(index<m-1){
            slow=slow.next;
            fast=fast.next;
            index++;
        }
        while(index<n){
            fast=fast.next;
            index++;
        }
        while(slow.next!=fast){
            ListNode temp=slow.next;
            slow.next=temp.next;
            temp.next=fast.next;
            fast.next=temp;
        }
        return fake.next;
    }
}