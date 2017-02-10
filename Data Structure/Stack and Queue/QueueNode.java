/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Fei
 */
import java.util.*;
public class QueueNode<E> {
    private static class Node<E>{
        private E element;
        private Node<E> next;
        public Node(E e){
            this.element=e;
        }
    }
    Node<E> top,last;
    public void add(E e){
        Node<E> temp=new Node<>(e);
        if(top==null){
            top=temp;
            last=temp;
        }
        else{
            last.next=temp;
            last=last.next;
        }
    }
    public E remove() throws Exception{
        if(top==null) throw new Exception("The Queue is Empty");
        E ele=top.element;
        top=top.next;
        if(top==null) last=null;
        return ele;
    }
    public E peek() throws Exception{
        if(top==null) throw new Exception("The Queue is Empty");
        return top.element;
    }
    public boolean isEmpty(){
        return top==null;
    }
}
