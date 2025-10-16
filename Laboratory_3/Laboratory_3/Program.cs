using static System.Net.Mime.MediaTypeNames;

namespace Laboratory_3
{
    static class Program
    {
        static readonly Text text = new Text("Hello, world! It's my pleasure. Let's go to the club... a, a's, able? На мне карат 5 лет");
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Print all sentences of the text in ascending order of the number of words");
                Console.WriteLine("2. Print all sentences of the text in ascending order of sentence length");
                Console.WriteLine("3. In interrogative sentences, find and print words of a given length (without duplicates)");
                Console.WriteLine("4. Remove from the text all words of a given length that start with a consonant letter");
                Console.WriteLine("5. In a specific sentence of the text, replace words of a given length with the specified substring");
                Console.WriteLine("6. Remove stopwords from the text");
                Console.WriteLine("7. Export the text to an XML document");
                Console.WriteLine("0. Exit the program");

                Console.Write("\nYour choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        text.PrintSentencesByWordsCount();
                        break;

                    case "2":
                        text.PrintSentencesByLength();
                        break;

                    case "3":
                        Command3();
                        break;

                    case "4":
                        Command4();
                        break;

                    case "5":
                        Command5();
                        break;

                    case "6":
                        text.RemoveStopWords();
                        break;

                    case "7":
                        text.ExportToXml("xmlText.xml");
                        break;

                    case "0":
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void Command3()
        {
            int length = ReadIntFromConsole("Input length: ");

            text.PrintWordsOfLengthInInterrogative(length);
        }

        private static void Command4()
        {
            int length = ReadIntFromConsole("Input length: ");

            text.RemoveWordsStartsOfConsonant(length);
        }

        private static void Command5()
        {
            int sentenceNumber = ReadIntFromConsole("Input sentences number: ");
            int length = ReadIntFromConsole("Input length: ");

            Console.WriteLine("Please, input word to replace it with");
            string newWord = Console.ReadLine() ?? "";

            text.ReplaceWordsInSentence(sentenceNumber - 1, length, newWord);
        }

        private static int ReadIntFromConsole(string text)
        {
            int number;
            while (true)
            {
                Console.Write(text);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            return number;
        }
    }
}
