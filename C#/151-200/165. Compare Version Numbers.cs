public class Solution {
    public int CompareVersion(string version1, string version2) {
        string[] strs1=version1.Split('.');
        string[] strs2=version2.Split('.');
        int max=strs1.Length>strs2.Length? strs1.Length : strs2.Length;
        int index=0;
        while(index<max){
            int num1 = index<strs1.Length? Int32.Parse(strs1[index]) : 0;
            int num2 = index<strs2.Length? Int32.Parse(strs2[index]) : 0;
            if(num1>num2) return 1;
            if(num2>num1) return -1;
            index++;
        }
        return 0;
    }
}