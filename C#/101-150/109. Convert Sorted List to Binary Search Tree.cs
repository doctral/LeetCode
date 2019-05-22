/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode SortedListToBST(ListNode head) {
        return BuildTree(head, null);
    }
    
    private TreeNode BuildTree(ListNode head, ListNode tail){
        if(head==tail) return null;
        ListNode slow=head, fast=head;
        while(fast!=tail && fast.next!=tail){
            slow=slow.next;
            fast=fast.next.next;
        }
        
        TreeNode root=new TreeNode(slow.val);
        root.left=BuildTree(head, slow);
        root.right=BuildTree(slow.next, tail);
        
        return root;
    }
}