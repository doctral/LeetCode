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

public class MyListImpl implements MyList {
    
    Node start;
    Node end;

    public Node getStart() { 
        return start; 
    }
    public Node getEnd()   {
        return end; 
    }

    public void add(Integer i) {
        Node n = new Node(i, end, null);
        if (start == null)
            start = n;
        if (end != null)
            end.next = n;
        end = n;
    }

    public MyListImpl() {
    }

    public MyListImpl(int[] arr) {
        for (int i: arr) {
            add(i);
        }
    }

    // Split /after/ index 'pos'
    public MyListImpl split(int pos) {
        MyListImpl second=new MyListImpl();
        Node split = start;
        for(; pos>=0; pos--)
            split = split.next;
        if (split == null)
            return second;
        second.start = split;
        second.end = end;
        end = split.previous;
        if (end != null)
            end.next = null;
        else
            start = null; // if end ==  null, then the first part is null
        return second;
    }
    // Not required by the lab, but helpful. Add two lists together.
    void add(MyList second) {
      // Use the name "first" as an alternate name for "this".
      // We are adding the second list to the first.
      final MyListImpl first = this;

      // If there's nothing to add, we're done
      if(second.getStart()==null) {
        return;
      }

      // If the first list is empty, then adding
      // them together just gives us the first.
      if(first.start == null) {
        first.start = second.getStart();
        first.end   = second.getEnd();
        return;
      }

      // Change the next pointer on the end node
      // of the first list to point to the start 
      // node of the second list.
      first.end.next = second.getStart();

      // Change the previous pointer on the
      // start node of the second list to point
      // to the end node of the first list.
      second.getStart().previous = this.end;

      // Change the first list's end pointer to
      // the second list's end pointer.
      first.end = second.getEnd();
    }    

    // Add /before/ index 'pos', with 'pos' being length of list being legal
    public void add(int pos, MyList second) {
      MyListImpl first = this;
      MyList third = new MyListImpl();
      if(first.start != null)
        third = first.split(pos-1);
      first.add(second);
      first.add(third);
    }

    public String toString() {
        if (start != null)
            return start.nextString();
        else
            return "";
    }

    public ArrayList<Integer> getData() {
        ArrayList<Integer> al = new ArrayList<>();
        Node next = start;
        while (next != null) {
            al.add(next.data);
            next = next.next;
        }
        return al;
    }
}

