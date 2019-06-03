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
    private Dictionary<Node, Node> map=new Dictionary<Node, Node>();
    public Node CloneGraph(Node node) {
        if(node==null) return null;
        map[node]=new Node(node.val, new List<Node>());
        foreach(Node n in node.neighbors){
            if(map.ContainsKey(n)){
                map[node].neighbors.Add(map[n]);
            }
            else{
                map[node].neighbors.Add(CloneGraph(n));
            }
        }
        return map[node];
    }
}