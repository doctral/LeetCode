/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode fake=new ListNode(0);
        ListNode copy=fake;
        fake.next=head;
        
        while(copy.next!=null){
            if(copy.next.val==val){
                copy.next=copy.next.next;
            }
            else{
                copy=copy.next;
            }
        }
        return fake.next;
    }
}