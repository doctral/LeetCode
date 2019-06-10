public class Solution {
    public int EvalRPN(string[] tokens) {
        HashSet<string> ops=new HashSet<string>(){"+", "-", "*", "/"};
        Stack<int> stack=new Stack<int>();
        int res=0;
        for(int i=0; i<tokens.Length; i++){
            if(ops.Contains(tokens[i])){
                int num1 = stack.Pop();
                int num2=stack.Pop();
                int temp=0;
                if(tokens[i]=="+"){
                    temp=num1+num2;
                }
                else if(tokens[i]=="-"){
                    temp=num2-num1;
                }
                else if(tokens[i]=="*"){
                    temp=num1*num2;
                }
                else{
                    temp=num2/num1;
                }
                stack.Push(temp);
            }
            else{
                stack.Push(Int32.Parse(tokens[i]));
            }
        }
        return stack.Pop();
    }
}