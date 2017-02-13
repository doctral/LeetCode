/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package binarysearchtree;
import java.util.*;

/**
 *
 * @author Fei
 */
public class BinarySearchTree {
    private class TreeNode<Integer>{
        public int element;
        public TreeNode<Integer> left,right;
        public TreeNode(int e){
            this.element=e;
        }
    }
    TreeNode<Integer> root;
    
    //Search for an element
    public boolean search(int e, TreeNode root){
        if(root!=null){
           TreeNode<Integer> parent=root;
           TreeNode<Integer> curr=root;
           while(curr!=null){
               if(e>curr.element){
                   parent=curr;
                   curr=curr.right;
               }
               else if(e<curr.element){
                   parent=curr;
                   curr=curr.left;
               }
               else{
                   return true;
               }
           }
        }
        return false;
    }
    
    // Insert an element into a BST
    // To insert the element into a BST, the key idea is to locate the parent for the new node
    public boolean insert(int e){
        if(root==null){
            root=new TreeNode<Integer>(e);
            return true;
        }
        else{
            TreeNode<Integer> curr=root;
            TreeNode<Integer> parent=root;
            while(curr!=null){
                if(e<curr.element){
                    parent=curr;
                    curr=curr.left;
                }
                else if(e>curr.element){
                    parent=curr;
                    curr=curr.right;
                }
                else{ // the element already existed, duplicate node found 
                    return false;
                }
            }
            if(e<parent.element){
                parent.left=new TreeNode<Integer>(e);
            }
            else{
                parent.right=new TreeNode<Integer>(e);
            }
            return true;
        }
    }
    
    // Deleting elements from a BST
    // First locate it in the tree and then consider two cases, before deleting the
    // element and reconnecting the tree, whether or not the node
    // has a left a child.
    // This method return true if the node is in the true, return false otherwise.
    public boolean delete(int e){
        TreeNode<Integer> parent=null;
        TreeNode<Integer> curr=root;
        while(curr!=null){
            if(e<curr.element){
                parent=curr;
                curr=curr.left;
            }
            else if(e>curr.element){
                parent=curr;
                curr=curr.right;
            }
            else{ // node is found as curr
                break;
            }
        }
        if(curr==null) return false; // not found the node
        // In this case, we replace the node with its predecessor
        // if no left child
        if(curr.left==null){
            // in this case, the target node is the root.
            if(parent==null){
                root=curr.right;
            }
            else{ // in this case, we connect the curr's parent to curr's right child
                  // but we need to know curr is the left or right child of its parent
                if(e<parent.element){
                    parent.left=curr.right;
                }
                else{
                    parent.right=curr.right;
                }
            }
        }
        else{ // curr has a predecessor
              // in this case, locate the predecessor (rightmost child in its left subtree) and its parent 
              TreeNode<Integer> preParent=curr;
              TreeNode<Integer> predecessor=curr.left;
              while(predecessor.right!=null){
                  preParent=predecessor;
                  predecessor=predecessor.right;
              }
              // now we find the predecessor, just replace the element
              curr.element=predecessor.element;
              // predecessor/sucessor only contains one or zero child
              if(preParent.right==predecessor){
                  preParent.right=predecessor.left;
              }
              else{ // in this case, curr's right is null, it has only left child
                  preParent.left=predecessor.left;
              }
        }
        return true;
    }
    
    public List<TreeNode<Integer>> findPath(int e){
        List<TreeNode<Integer>> res=new ArrayList<>();
        boolean found=false;
        TreeNode<Integer> curr=root;
        while(curr!=null){
            res.add(curr);
            if(e<curr.element){
                curr=curr.left;
            }
            else if(e>curr.element){
                curr=curr.right;
            }
            else{
                found=true;
                break;
            }
        }
        if(found){
            return res;
        }
        else{
            return new ArrayList<TreeNode<Integer>>();
        }
    }
    
    // Get the height of a binary tree
    public int height(TreeNode<Integer> root){
        if(root==null){
            return 0;
        }
        else{
            int left_height=height(root.left);
            int right_height=height(root.right);
            if(left_height>right_height){
                return left_height+1;
            }
            else{
                return right_height+1;
            }
        }
    }
    
    // find all elements at a specific level
    public void sameLevel(TreeNode<Integer> root, int n){
        if(root!=null && n>0){
            if(n==1){
                System.out.print(root.element+" ");
            }
            else{
                sameLevel(root.left, n-1);
                sameLevel(root.right,n-1);
            }
        }
    }
    
    public void printAllLevel(TreeNode<Integer> root){
        int h=height(root);
        for(int i=1; i<=h; i++){
            sameLevel(root,i);
            System.out.println();
        }
    }
    
    // Implement the BFS of Binary Search Tree using a Queue
    // override
    public void printAllLevel(){
       Queue<TreeNode<Integer>> queue=new LinkedList<>();
       queue.add(root);
       while(!queue.isEmpty()){
           TreeNode<Integer> temp=queue.poll();
           System.out.println(temp.element+" ");
           if(temp.left!=null){
               queue.add(temp.left);
           }
           if(temp.right!=null){
               queue.add(temp.right);
           }
       }
    }
    
    // implement inOrder of Binary Search Tree using Stack iteratively
    public List<Integer> inOrder(TreeNode<Integer> root){
        List<Integer> res=new ArrayList<>();
        Deque<TreeNode<Integer>> stack=new LinkedList<>();
        TreeNode<Integer> curr=root;
        while(!stack.isEmpty() ||curr!=null){
            while(curr!=null){
                stack.push(curr);
                curr=curr.left;
            }
            curr=stack.pop();
            res.add(curr.element);
            curr=curr.right;
        }
        return res;
    }
    
    // implement preOrder/DFS of Binary Search Tree using Stack
    public List<Integer> DFS(TreeNode<Integer> root){
        List<Integer> res=new ArrayList<>();
        Deque<TreeNode<Integer>> stack=new LinkedList<>();
        TreeNode<Integer> curr=root;
        while(curr!=null || !stack.isEmpty()){
            while(curr!=null){
                stack.push(curr);
                res.add(curr.element);
                curr=curr.left;
            }
            curr=stack.pop();
            curr=curr.right;
        }
        return res;
    }
    
    //implement postOrder of Binary Search Tree using Stack
    public List<Integer> postOrder(TreeNode<Integer> root){
        List<Integer> res=new ArrayList<>();
        Deque<TreeNode<Integer>> stack=new LinkedList<>();
        TreeNode<Integer> curr=root;
        while(curr!=null || !stack.isEmpty()){
            while(curr!=null){
                if(curr.right!=null) stack.push(curr.right);
                stack.push(curr);
                curr=curr.left;
            }
            curr=stack.pop();
            if(curr.right!=null && curr.right==stack.peek()){
                TreeNode<Integer> temp=stack.pop();
                stack.push(curr);
                curr=temp;
            }
            else{
                res.add(curr.element);
                curr=null;
            }
        }
        return res;
    }


    
}
