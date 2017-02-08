
import java.util.Iterator;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Fei
 */
public class MyLinkedList<E> extends MyAbstractList<E> {
    
    private static class Node<E>{
        E element;
        Node<E> next;
        public Node(E e){
            this.element=e;
        }
    }
    
    private Node<E> head, tail;
    
    public MyLinkedList(){
    }
    
    public MyLinkedList(E[] objects){
        super(objects);
    }
    
    public void addFirst(E e){
        Node<E> temp=new Node<E>(e);
        temp.next=head;
        head=temp;
        size++;
        if(tail==null) tail=head;
    }
    
    public void addLast(E e){
        Node<E> temp=new Node<E>(e);
        if(tail==null){
            tail=temp;
            head=temp;
        }
        else{
            tail.next=temp;
            tail=tail.next;
        }
        size++;
    }

    @Override
    public void add(int index, E e) {
        if(index<=0){
            addFirst(e);
        }
        else if(index>=size){
            addLast(e);
        }
        else{
            Node<E> curr=head;
            for(int i=0; i<index-1; i++){
                curr=curr.next;
            }
            Node<E> temp=curr.next;
            curr.next=new Node<E>(e);
            curr.next.next=temp;
            size++;
        }
    }

    public E removeFirst(){
        if(size==0) return null;
        Node<E> temp=head;
        head=head.next;
        if(head==null){
            tail=null;
        }
        size--;
        return temp.element;
    }
    
    public E removeLast(){
        if(size==0) return null;
        if(size==1){
            return removeFirst();
        }
        Node<E> curr=head;
        for(int i=0; i<size-2; i++){
            curr=curr.next;
        }
        Node<E> temp=curr.next;
        tail=curr;
        tail.next=null;
        size--;
        return temp.element;
    }
    
    public E getFirst(){
        if(size==0) return null;
        return head.element;
    }
    public E getLast(){
        if(size==0) return null;
        return tail.element;
    }
    
    @Override
    public void clear() {
        size=0;
        head=tail=null;
    }

    @Override
    public boolean contains(E e) {
        Node<E> curr=head;
        while(curr!=null){
            if(curr.element.equals(e)) return true;
            curr=curr.next;
        }
        return false;
    }

    @Override
    public E get(int index) {
        if(index<0 || index>=size){
            throw new IndexOutOfBoundsException("Index "+index+"out of bound");
        }
        if(index==0) return getFirst();
        if(index==size-1) return getLast(); 
        Node<E> curr=head;
        for(int i=0; i<index; i++){
            curr=curr.next;
        }
        return curr.element;
    }

    @Override
    public int indexOf(E e) {
        int index=0;
        Node<E> curr=head;
        while(index<size){
            if(curr.element.equals(e)){
                return index;
            }
            index++;
            curr=curr.next;
        }
        return -1;
        
    }

    @Override
    public int lastIndexOf(E e) {
        int index=-1;
        int i=0;
        Node<E> curr=head;
        while(i<size){
            if(curr.element.equals(e)){
                index=i;
            }
            i++;
            curr=curr.next;
        }
        return index;
    }

    @Override
    public E remove(int index) {
        if(index<0 ||index>=size) return null;
        if(index==0) return removeFirst();
        if(index==size-1) return removeLast();
        Node<E> curr=head;
        for(int i=0; i<index-1; i++){
            curr=curr.next;
        }
        Node<E> temp=curr.next;
        curr.next=curr.next.next;
        size--;
        return temp.element;
    }
    

    @Override
    public E set(int index, E e) {
        if(index<0 ||index>=size) return null;
        int i=0;
        Node<E> curr=head;
        while(i<index){
            curr=curr.next;
        }
        Node<E> old=curr;
        curr=new Node<E>(e);
        return old.element;
    }

    @Override
    public Iterator<E> iterator() {
        return new LinkedListIterator();
    }
    private class LinkedListIterator implements Iterator<E>{
        private Node<E> curr=head;
        public boolean hasNext(){
            return curr!=null;
        }
        public E next(){
            E e=curr.element;
            curr=curr.next;
            return e;
        }
        public void remove(){
            int index=indexOf(curr);
            MyLinkedList.this.remove(index);
        }
        
    }
    
    public String toString(){
        StringBuilder sb=new StringBuilder("[");
        Node<E> curr=head;
        for(int i=0; i<size; i++){
            sb.append(curr.element);
            curr=curr.next;
            if(curr!=null){
                sb.append(", ");
            }
        }
        sb.append("]");
        return sb.toString();
    }

    
    
}
