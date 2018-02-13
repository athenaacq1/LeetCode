public class Solution {
    public bool IsValid(string s) 
    {
        if(string.IsNullOrWhiteSpace(s))
            return true;
        
        var stack = new Stack<char>();
        foreach(var c in s.ToCharArray())
        {
            if( (c == '(') || (c == '{') || (c == '['))
                stack.Push(c);
            else if(c == ')')
            {
                if(stack.Count() <= 0)
                {
                    return false;
                }
                var top = stack.Peek();
                if(top == '(')
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
            else if(c == ']')
            {
                if(stack.Count() <= 0)
                {
                    return false;
                }
                var top = stack.Peek();
                if(top == '[')
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
            else if(c == '}')
            {
                if(stack.Count() <= 0)
                {
                    return false;
                }
                var top = stack.Peek();
                if(top == '{')
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        return stack.Count() == 0;
    }
}