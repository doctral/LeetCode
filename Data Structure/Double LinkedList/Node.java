/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Fei
 */
public class Node {
    // The actual data
    Integer data;
    // References to the previous and next element in a list. Can be null.
    Node previous;
    Node next;

    public Node() {
        
    }
    public Node(Integer d, Node p, Node n) {
        data = d;
        previous = p;
        next = n;
    }

    public String toString() {
        return Integer.toString(data);
    }

    // Returns a String representing this, and following elements.
    public String nextString() {
        String ret = Integer.toString(data);
        if (next != null)
            return ret + ", " + next.nextString();
        else
            return ret;
    }
}

