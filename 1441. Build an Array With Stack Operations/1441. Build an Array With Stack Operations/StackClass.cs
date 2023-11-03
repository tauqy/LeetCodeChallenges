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

        public IList<string> BuildArray2(int[] target, int n)
        {
            var hashSet = new HashSet<int>(target);
            var list = new List<string>();

            for (int i = 1; i <= target[target.Length-1]; i++)
            {
                if (hashSet.Contains(i))
                {
                    list.Add("Push");
                }
                else
                {
                    list.Add("Push");
                    list.Add("Pop");
                }
            }
            return list;
        }


    }
}
