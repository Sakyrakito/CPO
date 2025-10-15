using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Laboratory_3
{
    [Serializable]
    [XmlRoot("Text")]
    public class Text
    {
        [XmlElement("Sentence")]
        public List<Sentence> Sentences { get; } = new List<Sentence>();

        public Text(string text)
        {
            var parts = Regex.Split(text, @"(?<=[.!?])\s+");
            foreach (var p  in parts)
                if (!string.IsNullOrEmpty(p))
                    Sentences.Add(new Sentence(p.Trim()));
        }

        public void PrintSentencesByWordsCount()
        {
            foreach (var s in Sentences.OrderBy(s => s.WordsCount()).ToList())
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void PrintSentencesByLength()
        {
            foreach (var s in Sentences.OrderBy(s => s.Tokens.Count).ToList())
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void PrintWordsOfLengthInInterrogative(int length)
        {
            var sentences = Sentences.Where(s => s.Tokens[s.Tokens.Count - 1].Value.EndsWith('?')).ToList();

            HashSet<string> wordsFound = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var s in sentences)
            {
                var words = s.Tokens.Where(t => t.Value is Word && t.Value.Length == length).ToList();

                foreach (var w in words)
                {
                    if (wordsFound.Add(w.Value))
                    {
                        Console.WriteLine(w.Value);
                    }
                }
            }
        }

        public void RemoveWordsStartsOfConsonant(int length)
        {
            string vowels = "АаЕеЁёИиОоУуЫыЭэЮюЯяAaEeIiOoUuYy";

            for (int i = 0; i < Sentences.Count; i++)
            {
                var newWords = Sentences[i].Tokens.Where(t => t.Value.Length != length 
                || vowels.Contains(t.Value[0])).ToList();

                Sentences[i].Tokens.RemoveAll(t => !newWords.Contains(t));
            }
        }

        public void ReplaceWordsInSentence(int sentenceIndex, int length, string substring)
        {
            if (sentenceIndex < 0 || sentenceIndex >= Sentences.Count)
                throw new ArgumentOutOfRangeException(nameof(sentenceIndex));

            var words = Sentences[sentenceIndex].Tokens.Select(t => (t is Word && t.Value.Length == length)
            ? new Word(substring) : t).ToList();

            //Sentences[sentenceIndex].Tokens = words;
        }

        public void ExportToXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(Text));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, this);
            }
        }

        public override string ToString() => string.Join(" ", Sentences);
    }
}
