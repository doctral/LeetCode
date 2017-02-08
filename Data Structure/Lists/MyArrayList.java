
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
public class MyArrayList<E> extends MyAbstractList<E> {
    public static final int INITIAL_CAPACITY=16;
    private E[] data=(E[])(new Object[INITIAL_CAPACITY]); 
    
    public MyArrayList(){
    }
    
    public MyArrayList(E[] objects){
        for(int i=0; i<objects.length; i++){
            add(objects[i]);
        }
    }

    @Override
    public void add(int index, E e) {
        ensureCapacity();
        for(int i=size-1; i>=index; i--){
            data[i+1]=data[i];
        }
        data[index]=e;
        size++;
    }
    private void ensureCapacity(){
        if(size>=data.length){
            E[] newData=(E[])(new Object[size*2+1]);
            System.arraycopy(data, 0, newData, 0, size);
            data=newData;
        }
    }

    @Override
    public void clear() {
        data=(E[])new Object[INITIAL_CAPACITY];
        size=0;
    }

    @Override
    public boolean contains(E e) {
        for(int i=0; i<size; i++){
            if(e.equals(data[i])) return true;
        }
        return false;
    }

    @Override
    public E get(int index) {
        checkIndex(index);
        return data[index]; 
    }
    
    private void checkIndex(int index){
        if(index<0 ||index>=size){
            throw new IndexOutOfBoundsException("index"+index+"out of bound");
        }
    }

    @Override
    public int indexOf(E e) {
        for(int i=0; i<size; i++){
            if(e.equals(data[i])) return i;
        }
        return -1;
    }

    @Override
    public int lastIndexOf(E e) {
        for(int i=size-1; i>=0; i--){
            if(e.equals(data[i])) return i;
        }
        return -1;
    }

    @Override
    public E remove(int index) {
        checkIndex(index);
        E e=data[index];
        for(int i=index; i<size-1; i++){
            data[i]=data[i+1];
        }
        data[size-1]=null;
        size--;
        return e;
    }

    @Override
    public E set(int index, E e) {
        checkIndex(index);
        E old=data[index];
        data[index]=e;
        return old;
    }

    @Override
    public Iterator<E> iterator() {
        return new ArrayListIterator();
    }
  
    private class ArrayListIterator implements Iterator<E>{
        private int curr=0;
        @Override
        public boolean hasNext() {
            return curr<size;
        }

        @Override
        public E next() {
            return data[curr+1];
        }

        @Override
        public void remove() {
            MyArrayList.this.remove(curr);
        }
    }
    
    public void trimToSize(){
        if(size!=data.length){
            E[] newData=(E[])(new Object[size]);
            for(int i=0; i<size; i++){
                newData[i]=data[i];
            }
            data=newData;
        }
    }
    
    public String toString(){
        StringBuilder sb=new StringBuilder("[");
        for(int i=0; i<size; i++){
            sb.append(data[i]);
            if(i<size-1) sb.append(", ");
        }
        sb.append("]");
        return sb.toString();
        
    }
    
}
