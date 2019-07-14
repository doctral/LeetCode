public class Solution {
    public int Calculate(string s) {
        int res=0, sign=1, index=0;
        Stack<int> stack=new Stack<int>();
        while(index<s.Length){
            char ch=s[index];
            if(ch=='+'){
                sign=1;
            }
            else if(ch=='-'){
                sign=-1;
            }
            else if(ch=='('){
                stack.Push(res);
                stack.Push(sign);
                res=0;
                sign=1;
            }
            else if(ch==')'){
                int ss = stack.Pop();
                int temp=stack.Pop();
                res = res*ss + temp;
            }
            else if(ch>='0' && ch<= '9'){
                int num = ch-'0';
                while(index+1<s.Length && '0'<=s[index+1] && s[index+1]<='9'){
                    num = num*10 + (s[index+1]-'0');
                    index++;
                }
                res+=num*sign;
            }
            index++;
        }
        return res;
    }
}