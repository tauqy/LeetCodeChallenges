using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1441._Build_an_Array_With_Stack_Operations
{
    public class StackClass
    {
        public IList<string> BuildArray(int[] target, int n)
        {
            var list = new List<string>();
            var stack = new Stack<int>();
            int count = 0;

            for(int i = 0; i < n; i++)
            {
                if (target.Length > count) {
                    stack.Push(i + 1);
                    list.Add("Push");
                    if ( stack.Peek() != target[count++])
                    {
                        stack.Pop();
                        list.Add("Pop");
                        count--;
                    }
                }
            }
            return list;
        }
    }
}
