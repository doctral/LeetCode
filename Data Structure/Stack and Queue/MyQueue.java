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
public class MyQueue<E> {
    private LinkedList<E> list=new LinkedList<>();
    public void enqueue(E e){
        list.addLast(e);
    }
    public E dequeue(){
        return list.removeFirst();
    }
    public int getSize(){
        return list.size();
    }
    public String toString(){
        return list.toString();
    }
}
