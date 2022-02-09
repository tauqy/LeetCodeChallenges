using System;
using System.Collections.Generic;

namespace _438._Find_All_Anagrams_in_a_String
{
    class Program
    {
        /**
         *Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

 

Example 1:

Input: s = "cbaebabacd", p = "abc"
Output: [0,6]
Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".
Example 2:

Input: s = "abab", p = "ab"
Output: [0,1,2]
Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".
         **/
        static void Main(string[] args)
        {
            var res = FindAnagrams("cbaebabacd", "abc");
            Console.WriteLine(res.ToString());
        }

        private static IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            if (p.Length > s.Length)
                return result;
            Dictionary<char, int> pMap = new Dictionary<char, int>();
            Dictionary<char, int> sMap = new Dictionary<char, int>();

            foreach(char ch in p)
            {
                if (!pMap.ContainsKey(ch))
                {
                    pMap.Add(ch, 1);
                } else
                {
                    pMap[ch]++;
                }
            }

            int left = 0;
            int right = 0;
            int size = s.Length;
            int windowSize = p.Length;

            while(right < size)
            {
                if (sMap.ContainsKey(s[right]))
                {
                    sMap[s[right]]++;
                } else
                {
                    sMap[s[right]] = 1;
                }

                if (right - left + 1 < windowSize)
                    right++;
                else if(right - left + 1 == windowSize)
                {
                    if(AreMapEqual(sMap, pMap))
                    {
                        result.Add(left);
                    }
                    //Sliding Window
                    if (sMap.ContainsKey(s[left]))
                    {
                        sMap[s[left]]--;
                        if(sMap[s[left]] == 0)
                        {
                            sMap.Remove(s[left]) ;
                        }
                    }
                    left++;
                    right++;
                }
            }

            return result.ToArray();
        }

        private static bool AreMapEqual(Dictionary<char, int> s, Dictionary<char, int> p)
        {
            if (s.Count != p.Count)
                return false;
            foreach(char ch in s.Keys)
            {
                if (!p.ContainsKey(ch) || s[ch] != p[ch])
                    return false;
            }
            return true;
        }
    }
}
