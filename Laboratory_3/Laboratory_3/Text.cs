using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Laboratory_3
{
    [Serializable]
    [XmlRoot("Text")]
    public class Text
    {
        [XmlElement("Sentence")]
        public List<Sentence> Sentences { get; set; } = new List<Sentence>();

        public Text(string text)
        {
            var parts = Regex.Split(text, @"(?<=[.!?])\s+");
            foreach (var p in parts)
                if (!string.IsNullOrEmpty(p))
                    Sentences.Add(new Sentence(p.Trim()));
        }

        public Text() { }

        public void PrintSentencesByWordsCount()
        {
            foreach (var s in Sentences.OrderBy(s => s.WordsCount()).ToList())
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void PrintSentencesByLength()
        {
            foreach (var s in Sentences.OrderBy(s => s.Tokens.Sum(t => t.Value.Length) + 
            s.WordsCount() - 1).ToList())
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
                var words = s.Tokens.Where(t => t is Word && t.Value.Length == length).ToList();

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
            string vowels = "АаЕеЁёИиОоУуЫыЭэЮюЯяAaEeIiOoUuYy0123456789";

            for (int i = 0; i < Sentences.Count; i++)
            {
                var newWords = Sentences[i].Tokens.Where(t =>
                t is Punctuation ||
                t is Word &&
                (t.Value.Length != length ||
                vowels.Contains(t.Value[0]))).ToList();

                Sentences[i].Tokens.RemoveAll(t => !newWords.Contains(t));
            }
        }

        public void ReplaceWordsInSentence(int sentenceIndex, int length, string substring)
        {
            if (sentenceIndex < 0 || sentenceIndex >= Sentences.Count)
                throw new ArgumentOutOfRangeException(nameof(sentenceIndex));

            var words = Sentences[sentenceIndex].Tokens.Select(t => (t is Word && t.Value.Length == length)
            ? new Word(substring) : t).ToList();

            Sentences[sentenceIndex].ChangeWords(words);
        }

        public void RemoveStopWords()
        {
            var englishStopWord = File.ReadAllLines("stopwords_en.txt")
                .Select(w => w.Trim().ToLower())
                .ToHashSet();

            var russianStopWord = File.ReadAllLines("stopwords_ru.txt")
                .Select(w => w.Trim().ToLower())
                .ToHashSet();

            for (int i = 0; i < Sentences.Count; i++)
            {
                var newWords = Sentences[i].Tokens.Where(w => 
                !englishStopWord.Contains(w.Value.ToLower()) && 
                !russianStopWord.Contains(w.Value.ToLower())).ToList();

                Sentences[i].ChangeWords(newWords);
            }
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
