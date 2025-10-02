using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboratory_2;

public class CommandManager
{
    readonly CommandExecute commandExecute = new CommandExecute("sequences.0.txt");
    private int commandNumber = 0;

    public void ReadCommands()
    {
        WriteAnswerInFile("Sinkevich Uladzimir");
        WriteAnswerInFile("Genetic Searching");

        using (StreamReader reader = new StreamReader("commands.0.txt"))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                WriteAnswerInFile(new string('-', 100));
                
                commandNumber++;
                var command = line.Split('\t');
                
                switch (command[0])
                {
                    case "search":
                        ProcessingSearchCommand(command[1]);
                        break;
                    case "diff":
                        ProcessingDiffCommand(command[1], command[2]);
                        break;
                    case "mode":
                        ProcessingModeComand(command[1]);
                        break;
                    default: break;
                }
            }
            WriteAnswerInFile(new string('-', 100));
        }
    }

    private void ProcessingSearchCommand(string aminoAcid)
    {
        WriteAnswerInFile($"{commandNumber.ToString("D3")}\tsearch\t{aminoAcid}");

        aminoAcid = RLDecoding(aminoAcid);

        // can be empty
        var genericDataWithAminoAcid = commandExecute.CommandReadImplementation(aminoAcid);

        WriteAnswerInFile("organism\tprotein");
        if (genericDataWithAminoAcid.Count != 0)
        {
            foreach (var genericData in genericDataWithAminoAcid)
            {
                WriteAnswerInFile(genericData.Organizm + "\t" + genericData.Protein);
            }
        }
        else
        {
            WriteAnswerInFile("NOT FOUND");
        }
    }

    private void ProcessingDiffCommand(string protein1, string protein2)
    {
        WriteAnswerInFile($"{commandNumber.ToString("D3")}\tdiff\t{protein1}\t{protein2}");
        WriteAnswerInFile("amino-acid difference:");

        // if -1 => missing: protein 1
        // if -2 => missing: protein 2
        // if -3 => missing: protein 1 and 2
        int difference = commandExecute.CommandDiffImplementation(protein1, protein2);

        switch (difference)
        {
            case -1:
                WriteAnswerInFile($"MISSING: {protein1}");
                break;
            case -2:
                WriteAnswerInFile($"MISSING: {protein2}");
                break;
            case -3:
                WriteAnswerInFile($"MISSING: {protein1}, {protein2}");
                break;
            default:
                WriteAnswerInFile($"{difference}");
                break;
        }
    }

    private void ProcessingModeComand(string protein)
    {
        WriteAnswerInFile($"{commandNumber.ToString("D3")}\tmode\t{protein}");
        WriteAnswerInFile("amino-acid occurs:");

        // occurs can be -1
        var (aminoAcid, occurs) = commandExecute.CommandModeImplementation(protein);

        if (occurs == -1)
            WriteAnswerInFile($"MISSING: {protein}");
        else
            WriteAnswerInFile($"{aminoAcid}\t{occurs}");
    }

    private static void WriteAnswerInFile(string message)
    {
        using (StreamWriter writer = new StreamWriter("genedata.0.txt", append: true))
        {
            writer.WriteLine(message);
        }
    }

    private static string RLDecoding(string aminoAcid)
    {
        StringBuilder fullAminoAcid = new StringBuilder();

        for (int i = 0; i < aminoAcid.Length; i++)
        {
            if (aminoAcid[i] >= '0' && aminoAcid[i] <= '9')
            {
                int number = 0;
                int j = i;
                while (j < aminoAcid.Length && aminoAcid[j] >= '0' && aminoAcid[j] <= '9')
                {
                    number *= 10;
                    number += aminoAcid[j] - '0';
                    j++;
                }

                while (number > 0)
                {
                    fullAminoAcid.Append(aminoAcid[j]);
                    number--;
                }

                i = j;
            }
            else
            {
                fullAminoAcid.Append(aminoAcid[i]);
            }
        }

        return fullAminoAcid.ToString();
    }
}
