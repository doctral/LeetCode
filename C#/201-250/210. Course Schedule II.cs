public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, IList<int>> map=new Dictionary<int, IList<int>>();
        int[] indegree=new int[numCourses];
        Queue<int> q=new Queue<int>();
        for(int i=0; i<prerequisites.Length; i++){
            int course=prerequisites[i][0];
            int pre=prerequisites[i][1];
            if(!map.ContainsKey(pre)) map[pre]=new List<int>();
            map[pre].Add(course);
            indegree[course]++;
        }
        
        IList<int> res=new List<int>();
        for(int i=0; i<numCourses; i++){
            if(indegree[i]==0) q.Enqueue(i);
        }
        
        while(q.Count>0){
            int pre=q.Dequeue();
            res.Add(pre);
            if(!map.ContainsKey(pre)) continue;
            foreach(int c in map[pre]){
                indegree[c]--;
                if(indegree[c]==0) q.Enqueue(c);
            }
        }
        
        int[] result=new int[numCourses];
        if(res.Count<numCourses) return new int[0];
        for(int i=0; i<numCourses; i++){
            result[i]=res[i];
        }
        return result;
    }
}