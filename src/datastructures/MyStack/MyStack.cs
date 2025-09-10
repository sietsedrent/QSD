namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        public MyLinkedList<T> list = new MyLinkedList<T>();

        public bool IsEmpty()
        {
            return list.Size == 0;
        }

        public void Push(T data)
        {
            // Add element to the front of the list (top of stack)
            list.AddFirst(data);
        }

        public T Top()
        {
            if (IsEmpty())
            {
                throw new MyStackEmptyException();
            }
            
            // Return the first element without removing it
            return list.GetFirst();
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new MyStackEmptyException();
            }
            
            // Get the top element and remove it
            T topElement = list.GetFirst();
            list.RemoveFirst();
            return topElement;
        }
    }

    // Bracket checking implementations
    public static class BracketChecker
    {
        public static bool CheckBrackets(string s)
        {
            MyStack<char> stack = new MyStack<char>();
            
            foreach (char c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.IsEmpty())
                    {
                        return false; // Closing bracket without matching opening bracket
                    }
                    stack.Pop();
                }
                // Ignore other characters
            }
            
            // Stack should be empty if all brackets are matched
            return stack.IsEmpty();
        }

       
        public static bool CheckBrackets2(string s)
        {
            MyStack<char> stack = new MyStack<char>();
            
            foreach (char c in s)
            {
                // Push opening brackets onto stack
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // Check closing brackets
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.IsEmpty())
                    {
                        return false; // Closing bracket without matching opening bracket
                    }
                    
                    char openingBracket = stack.Pop();
                    
                    // Check if the closing bracket matches the most recent opening bracket
                    if (!IsMatchingPair(openingBracket, c))
                    {
                        return false; // Mismatched bracket types
                    }
                }
                // Ignore other characters
            }
            
            // Stack should be empty if all brackets are matched
            return stack.IsEmpty();
        }

        private static bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '[' && closing == ']') ||
                   (opening == '{' && closing == '}');
        }
    }
}
