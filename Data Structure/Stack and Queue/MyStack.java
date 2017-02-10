
import java.util.*;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Fei
 */
public class MyStack<E>{
    private List<E> list=new ArrayList<E>();
    public int getSize(){
        return list.size();
    }
    public E peek(){
        return list.get(list.size()-1);
    }
    public void push(E e){
        list.add(e);
    }
    public E pop(){
        return list.remove(list.size()-1);
    }
    public boolean isEmpty(){
        return list.size() ==0;
    }
    public String toString(){
        return list.toString();
    }
    
}
