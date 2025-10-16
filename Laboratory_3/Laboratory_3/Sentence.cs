using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laboratory_3
{
    [Serializable]
    public class Sentence
    {
        [XmlElement("Word", Type = typeof(Word))]
        [XmlElement("Punctuation", Type = typeof(Punctuation))]
        public List<Token> Tokens { get; set; } = new List<Token>();

        public Sentence(string text) 
        {
            var mathes = Regex.Matches(text, @"[A-Za-zА-Яа-яЁё0-9]+(?:['-][A-Za-zА-Яа-яЁё0-9]+)*|\.{3}|[^\w\s]");

            foreach (Match match in mathes)
            {
                string value = match.Value;
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЁё0-9]+(?:['-][A-Za-zА-Яа-яЁё0-9]+)*$"))
                    Tokens.Add(new Word(value));
                else
                    Tokens.Add(new Punctuation(value));
            }
        }

        public Sentence() { }

        public int WordsCount()
        {
            return Tokens.Count(t => t is Word);
        }

        public void ChangeWords(List<Token> tokens)
        {
            Tokens = tokens;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            foreach (var token in Tokens)
            {
                if (token is Word)
                    text.Append(token.ToString() + " ");
                else
                {
                    if (text.Length > 0)
                        text.Remove(text.Length - 1, 1);
                    text.Append(token.ToString() + " ");
                }
            }

            return text.ToString();
        }
    }
}
