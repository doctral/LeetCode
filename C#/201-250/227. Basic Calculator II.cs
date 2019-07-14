public class Solution {
    public int Calculate(string s) {
        Stack<char> signs=new Stack<char>();
        Stack<int> nums=new Stack<int>();
        int index=0;
        while(index<s.Length){
            char ch=s[index];
            if(ch=='+'){
                signs.Push(ch);
            }
            else if(ch=='-'){
                signs.Push(ch);
            }
            else if(ch=='*'){
                int pre=nums.Pop();
                int next=0;
                while(index+1<s.Length && (s[index+1]<='9' && s[index+1]>='0' || s[index+1]==' ') ){
                    index++;
                    if(s[index]==' ') continue;
                    next = next *10 + (s[index]-'0');
                }
                nums.Push(pre*next);
            }
            else if(ch=='/'){
                int pre=nums.Pop();
                int next=0;
                while(index+1<s.Length && (s[index+1]<='9' && s[index+1]>='0' || s[index+1]==' ') ){
                    index++;
                    if(s[index]==' ') continue;
                    next = next *10 + (s[index]-'0');
                }
                nums.Push(pre/next);
            }
            else if(ch>='0' && ch<='9'){
                int num=ch-'0';
                while(index+1<s.Length && (s[index+1]>='0' && s[index+1]<='9' || s[index+1]==' ') ){
                    index++;
                    if(s[index]==' ') continue;
                    num = num * 10 + (s[index]-'0');
                }
                nums.Push(num);
            }
            index++;
        }
        
        int res = 0;
        while(signs.Count>0){
            char sign = signs.Pop();
            int curr = nums.Pop();
            if(sign=='-') curr=curr*(-1);
            res = res + curr;
        }
        if(nums.Count>0){
            res+=nums.Pop();
        }
        return res;
    }
}