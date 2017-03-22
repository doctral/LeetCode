/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Fei
 */
import java.util.ArrayList;

public interface MyList {

    /**
     * Return a reference to the first and last element of the list, respectively; or
     * null if the list is empty.
     */
    public Node getStart();
    public Node getEnd();
    
    /**
     * Add a single element to the list, appended to the end.
     */
    public void add(Integer i);

    /**
     * Split list /after/ index 'pos'. This list will be cut, and the part that was cut
     * (the second part) will be returned as new MyList.
     */
    public MyList split(int pos); 

    /**
     * Add new list /before/ index 'pos'. pos equal to length of list is legal, and appends
     * the list to the end.
     */
    public void add(int pos, MyList list);

    /**
     * Return the content of the List as ArrayList of Integers
     */
    public ArrayList<Integer> getData();

    /**
     * Some output, good for debugging.
     */
    public String toString();


}
