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
            var mathes = Regex.Matches(text, @"[A-Za-zА-Яа-яЁё0-9]+(?:['-][A-Za-zА-Яа-яЁё0-9]+)*|\.{1,3}|[^\w\s]");

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

        public void PrintWordsOfGivenLength(int length)
        {
            var words = Tokens.Where(t => t is Word && t.Value.Length == length).ToList();
            HashSet<string> wordsFound = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var w in words)
            {
                if (wordsFound.Add(w.Value))
                {
                    Console.WriteLine(w.Value);
                }
            }
        }

        public void RemoveWordsStartsOfConsonant(int length)
        {
            string consonant = "БбВвГгДдЖжЗзЙйКкЛлМмНнПпРрСсТтФфХхЦцЧчШшЩщBbCcDdFfGgHhJjKkLlMmNnPpQqRrSsTtVvWwXxYyZz";

            var newWords = Tokens.Where(t =>
                t is Punctuation ||
                t is Word &&
                (t.Value.Length != length ||
                !consonant.Contains(t.Value[0]))).ToList();

            Tokens.RemoveAll(t => !newWords.Contains(t));
        }

        public void ReplaceWords(int length, string substring)
        {
            var words = Tokens.Select(t =>
            (t is Word && t.Value.Length == length)
            ? new Word(substring) : t).ToList();

            Tokens = words;
        }

        public void RemoveStopWords(HashSet<string> englishStopWord, HashSet<string> russianStopWord)
        {
            var newWords = Tokens.Where(w =>
                !englishStopWord.Contains(w.Value.ToLower())
                && !russianStopWord.Contains(w.Value.ToLower())).ToList();

            Tokens = newWords;
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
