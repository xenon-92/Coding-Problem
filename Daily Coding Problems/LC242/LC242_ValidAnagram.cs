using System;
using System.Collections.Generic;

namespace LC242
{
    /*
     Input: s = "anagram", t = "nagaram"
     Output: true
    Input: s = "rat", t = "car"
    Output: false

     */
    class LC242_ValidAnagram
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var result = s.IsAnagram("baaaaa", "aaqaab");
        }
    }
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> hashmap = new Dictionary<char, int>();
            int i = 0;
            while (i < s.Length)
            {
                if (hashmap.ContainsKey(s[i]))
                {
                    hashmap[s[i]] += 1;
                }
                else
                {
                    hashmap.Add(s[i], 1);
                }
                i += 1;
            }
            i = 0;
            while (i < t.Length)
            {
                if (hashmap.ContainsKey(t[i]))
                {
                    hashmap[t[i]] -= 1;
                }
                else //new character
                {
                    return false;
                }
                i += 1;
            }
            var vals = hashmap.Values;
            foreach (var item in vals)
            {
                if (item != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
