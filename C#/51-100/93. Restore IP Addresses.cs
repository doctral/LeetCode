public class Solution {
    public IList<string> RestoreIpAddresses(string s) {
        IList<string> res=new List<string>();
        if(s.Length<4 || s.Length>12) return res;
        Backtrack(res, s, new List<string>(), 0);
        return res;
    }
    
    private void Backtrack(IList<string> res, string s, IList<string> temp, int index){
       if(temp.Count==4){
           if(index!=s.Length) return;
           StringBuilder sb=new StringBuilder();
           for(int i=0; i<temp.Count; i++){
               sb.Append(temp[i]);
               if(i<3) sb.Append('.');
           }
           res.Add(sb.ToString());
           return;
       }
       for(int i=index; i<s.Length && i<index+3; i++){
           string str=s.Substring(index, i-index+1);
           if(Valid(str)){
               temp.Add(str);
               Backtrack(res, s, temp, i+1);
               temp.RemoveAt(temp.Count-1);
           }
       } 
    }
    
    private bool Valid(string str){
        if(str[0]=='0') return str=="0";
        int num=Convert.ToInt32(str);
        return num>=1 && num<=255; 
    }
}