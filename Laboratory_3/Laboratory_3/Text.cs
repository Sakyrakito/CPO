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

        public void PrintSentences()
        {
            foreach (var sentence in Sentences)
            {
                Console.WriteLine(sentence.ToString());
            }
        }

        public void PrintSentencesByWordsCount()
        {
            Sentences = Sentences.OrderBy(s => s.WordsCount()).ToList();
            foreach (var s in Sentences)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void PrintSentencesByLength()
        {
            Sentences = Sentences.OrderBy(s =>
            s.Tokens.Sum(t => t.Value.Length) + s.WordsCount() - 1).ToList();
            
            foreach (var s in Sentences)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void PrintWordsOfLengthInInterrogative(int length)
        {
            var sentences = Sentences.Where(s => s.Tokens[s.Tokens.Count - 1].Value.EndsWith('?')).ToList();

            foreach (var s in sentences)
            {
                s.PrintWordsOfGivenLength(length);
            }
        }

        public void RemoveWordsStartsOfConsonant(int length)
        {
            foreach(var s in Sentences)
            {
                s.RemoveWordsStartsOfConsonant(length);
            }
        }

        public void ReplaceWordsInSentence(int sentenceIndex, int length, string substring)
        {
            if (sentenceIndex < 0 || sentenceIndex >= Sentences.Count)
                throw new ArgumentOutOfRangeException(nameof(sentenceIndex));

            Sentences[sentenceIndex].ReplaceWords(length, substring);

            Console.WriteLine("Final sentences:");
            PrintSentences();
        }

        public void RemoveStopWords()
        {
            var englishStopWord = File.ReadAllLines("stopwords_en.txt")
                .Select(w => w.Trim().ToLower())
                .ToHashSet();

            var russianStopWord = File.ReadAllLines("stopwords_ru.txt")
                .Select(w => w.Trim().ToLower())
                .ToHashSet();

            foreach (var s in Sentences)
            {
                s.RemoveStopWords(englishStopWord, russianStopWord);
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

        public void BuildConcordance()
        {
            SortedDictionary<string, (int, HashSet<int>)> concordance = new SortedDictionary<string, (int, HashSet<int>)>();

            for (int i = 0; i < Sentences.Count; i++)
            {
                foreach (var token in Sentences[i].Tokens)
                {
                    if (token is not Word)
                        continue;

                    string word = token.Value.ToLower();

                    if (!concordance.ContainsKey(word.ToString()))
                        concordance.Add(word.ToString(), (1, new HashSet<int> { i + 1 }));
                    else
                    {
                        var (count, line) = concordance[word.ToString()];
                        line.Add(i + 1);
                        concordance[word] = (count + 1, line);
                    }
                }
            }

            foreach (var (word, (count, line)) in concordance)
            {
                Console.Write(word + " | " + count + " | ");
                foreach (var index in line)
                    Console.Write(index.ToString() + "  ");

                Console.WriteLine();
            }
        }

        public override string ToString() => string.Join(" ", Sentences);
    }
}
