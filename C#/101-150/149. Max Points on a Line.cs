public class Solution {
    public int MaxPoints(int[][] points) {
        int res=0;
        HashSet<string> used =new HashSet<string>();
        for(int i=0; i<points.GetLength(0); i++){
            string encoded=points[i][0]+"#"+points[i][1];
            if(used.Contains(encoded)) continue;
            used.Add(encoded);
            
            int same=0, vertical=0, maxSlopes=0;
            Dictionary<string, int> slopes=new Dictionary<string, int>();
            
            for(int j=i+1; j<points.GetLength(0); j++){
                if(points[j][0]==points[i][0] && points[j][1]==points[i][1]){
                    same++;
                }
                else if(points[i][0]==points[j][0]){
                    vertical++;
                }
                else{
                    int xdiff=points[j][0]-points[i][0];
                    int ydiff=points[j][1]-points[i][1];
                    int gcd=GCD(xdiff, ydiff);
                    string slope=(ydiff/gcd)+"#"+(xdiff/gcd);
                    if(!slopes.ContainsKey(slope)){
                        slopes[slope]=0;
                    }
                    slopes[slope]+=1;
                    if(maxSlopes<slopes[slope]) maxSlopes=slopes[slope];
                }
            }
            int max=Math.Max(vertical, maxSlopes)+1+same;
            if(max>res) res=max;
        }
        return res;
    }
    
    private int GCD(int x, int y){
        if(y==0) return x;
        return GCD(y, x%y);
    }
}