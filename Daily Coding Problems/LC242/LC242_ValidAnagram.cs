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
            var result = s.IsAnagramConscise("xyz", "xya");
        }
    }
    public class Solution
    {
        // Method 1 through dictionary
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

        // Method 2 through Array
        public bool IsAnagram_Through_Array(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            /*
             thought process, Since this question can contain only small cased character
            we create an array of size 26, where we can store the count of each character 
            starting from zero for character 'a' and ending at character 'z' for position 25

            def: tracker[now - 'a'] -> a has a ascii code of 97
            we count the occurence of character 'a' at 0th position
            we count the occurence of character 'b' at 1st position
            we count the occurence of character 'z' at 25th position
             */

            int[] tracker = new int[26];
            int i = 0;
            while (i < s.Length)
            {
                char now = s[i];
                // we start incrementing the counter for each occurence
                tracker[now - 'a'] += 1;
                i += 1;
            }
            i = 0;
            while (i < t.Length)
            {
                char now = t[i];
                // we start decrementing the counter for each occurence
                tracker[now - 'a'] -= 1;
                i += 1;
            }
            foreach (int item in tracker)
            {
                if (item != 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Method3 through array
        public bool IsAnagramConscise(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int i = 0;
            int[] tracker = new int[26];
            while (i < s.Length)
            {
                tracker[s[i] - 'a'] += 1;
                tracker[t[i] - 'a'] -= 1;
                i += 1;
            }
            foreach (var item in tracker)
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
