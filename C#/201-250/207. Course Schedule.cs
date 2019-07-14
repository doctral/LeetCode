public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, IList<int>> map=new Dictionary<int, IList<int>>();
        Queue<int> readyList=new Queue<int>();
        int[] inDegree=new int[numCourses];
        for(int i=0; i<prerequisites.GetLength(0); i++){
            int course=prerequisites[i][0];
            int pre=prerequisites[i][1];
            if(!map.ContainsKey(pre)) map[pre]=new List<int>();
            map[pre].Add(course);
            inDegree[course]++;
        }
        
        for(int i=0; i<inDegree.Length; i++){
            if(inDegree[i]==0) readyList.Enqueue(i);
        }
        
        int count=0;
        
        while(readyList.Count>0){
            int course=readyList.Dequeue();
            count++;
            if(map.ContainsKey(course)){
                foreach(int cc in map[course]){
                    inDegree[cc]--;
                    if(inDegree[cc]==0) readyList.Enqueue(cc);
                }
                
            }
        }
        
        return count==numCourses;
    }
}