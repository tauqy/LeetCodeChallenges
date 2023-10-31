using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._Zigzag_Conversion
{
    public class ZigZag
    {
        public string Convert(string s, int numRows)
        {
            if (numRows <= 1)
                return s;
            string[] ans = new string[numRows];
            int count = 0;
            bool goingUp = false;
            for (int i = 0; i < s.Length; i++)
            {
                ans[count] += s[i];
                if (goingUp)
                {
                    count--;
                    if(count == 0)
                        goingUp = false;
                }
                else
                {
                    count++;
                    if (count == numRows - 1)
                        goingUp = true;
                }
            }

            StringBuilder str = new StringBuilder();
            foreach (var word in ans)
            {
                str.Append(word);
            }
            return str.ToString();
        }
    }
}
