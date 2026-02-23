using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        public double? EndOfWord { get; set; } = null;
    }

    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();   
        }

        public void Insert(string word, double sentiment)
        {
            TrieNode current = _root;

            foreach (char ch in word)
            {
                if (!current.Children.TryGetValue(ch, out TrieNode? value))
                {
                    value = new TrieNode();
                    current.Children[ch] = value;
                }

                current = value;
            }

            current.EndOfWord = sentiment;
        }

        public double SearchNode(string s)
        {
            TrieNode current = _root;

            double stringSentiment = 0.0;
            double currentSentiment = 0.0;

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];

                if (!current.Children.ContainsKey(ch))
                {
                    stringSentiment += currentSentiment;
                    currentSentiment = 0.0;

                    current = _root;

                    if (current.Children.ContainsKey(ch))
                    {
                        i--;
                    }
                }
                else
                {
                    if (current.EndOfWord != null)
                    {
                        currentSentiment += current.EndOfWord ?? 0.0;
                    }

                    current = current.Children[ch];
                }
            }

            stringSentiment += currentSentiment;

            return stringSentiment;
        }
    }
}