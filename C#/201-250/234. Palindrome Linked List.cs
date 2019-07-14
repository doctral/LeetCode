/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsPalindrome(ListNode head) {
        IList<int> list=new List<int>();
        while(head!=null){
            list.Add(head.val);
            head=head.next;
        }
        
        for(int i=0, j=list.Count-1; i<j; i++, j--){
            if(list[i]!=list[j]) return false;
        }
        return true;
    }
}