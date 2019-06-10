/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode InsertionSortList(ListNode head) {
        if(head==null || head.next==null) return head;
        ListNode fake=new ListNode(0);
        fake.next=head;
        int max=head.val;
        
        while(head.next!=null){
            if(head.next.val<max){
                ListNode temp=head.next;
                head.next=temp.next;
                
                ListNode pre=fake;
                while(pre.next!=null && pre.next.val<=temp.val){
                    pre=pre.next;
                }
                temp.next=pre.next;
                pre.next=temp;
            }
            else{
                max=head.next.val;
                head=head.next;
            }
        }
        
        return fake.next;
        
    }
}