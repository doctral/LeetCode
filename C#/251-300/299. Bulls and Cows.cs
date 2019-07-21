public class Solution {
    public string GetHint(string secret, string guess) {
        int[] nums=new int[10];
        foreach(char ch in secret){
            nums[ch-'0']++;
        }
        int b=0, a=0;
        foreach(char ch in guess){
            if(nums[ch-'0']>0){
                nums[ch-'0']--;
                b++;
            }
        }
        
        for(int i=0; i<secret.Length; i++){
            if(secret[i]==guess[i]){
                a++;
                b--;
            }
        }
        
        return a+"A"+b+"B";
    }
}