/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node(){}
    public Node(int _val,IList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
}
*/
public class Solution {
    public Node CloneGraph(Node node) {
        if(node==null) return null;
        Dictionary<Node, Node> map=new Dictionary<Node, Node>();
        Queue<Node> q=new Queue<Node>();
        q.Enqueue(node);
        map[node]=new Node(node.val, new List<Node>());
        
        while(q.Count>0){
            Node curr=q.Dequeue();
            foreach(Node n in curr.neighbors){
                if(map.ContainsKey(n)){
                    map[curr].neighbors.Add(map[n]);
                }
                else{
                    map[n]=new Node(n.val, new List<Node>());
                    map[curr].neighbors.Add(map[n]);
                    q.Enqueue(n);
                }
            }
        }
        
        return map[node];
    }
}