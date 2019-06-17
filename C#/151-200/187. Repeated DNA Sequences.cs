public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        Dictionary<string, int> map=new Dictionary<string, int>();
        IList<string> res=new List<string>();
        for(int i=0; i<=s.Length-10; i++){
            string str=s.Substring(i,10);
            if(!map.ContainsKey(str)) map[str]=0;
            map[str]++;
        }
        foreach(string str in map.Keys ){
            if(map[str]>1) res.Add(str);
        }
        return res;
    }
}