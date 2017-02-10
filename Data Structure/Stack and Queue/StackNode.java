
import java.util.EmptyStackException;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Fei
 */
public class StackNode<E> {
    private static class Node<E>{
        private E element;
        private Node<E> next;
        public Node(E e){
            this.element=e;
        }
    }
    private Node<E> top;
    public void push(E e){
        Node<E> temp=new Node<>(e);
        temp.next=top;
        top=temp;
    }
    public E pop(){
        if(top==null) throw new EmptyStackException();
        E old=top.element;
        top=top.next;
        return old;
    }
    public E peek(){
        if(top==null) throw new EmptyStackException();
        return top.element;
    }
    
    public boolean isEmpty(){
        return top==null;
    }
    
}
