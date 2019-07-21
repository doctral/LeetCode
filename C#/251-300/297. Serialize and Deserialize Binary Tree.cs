/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        StringBuilder sb=new StringBuilder();
        Serialize(root, sb);
        return sb.ToString();
    }
    
    private void Serialize(TreeNode root, StringBuilder sb){
        if(root==null){
            sb.Append("# ");
            return;
        } 
        sb.Append(root.val+" ");
        Serialize(root.left, sb);
        Serialize(root.right, sb);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        string[] strs=data.Split(' ');
        Queue<string> queue=new Queue<string>();
        foreach(string str in strs){
            queue.Enqueue(str);
        }
        return Deserialize(queue);
    }
    
    private TreeNode Deserialize(Queue<string> queue){
        if(queue.Count==0) return null;
        string str=queue.Dequeue();
        if(str=="#") return null;
        TreeNode root=new TreeNode(int.Parse(str));
        root.left=Deserialize(queue);
        root.right=Deserialize(queue);
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));