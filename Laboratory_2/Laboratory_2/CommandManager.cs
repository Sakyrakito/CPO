using System.Security.AccessControl;
using System.Text;

namespace Laboratory_2;

public class CommandManager
{
    CommandExecute commandExecute = new CommandExecute("");

    public void ReadCommands()
    {
        using (StreamReader reader = new StreamReader(""))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var command = line.Split("    ");
                
                switch (command[0])
                {
                    case "search":
                        ProcessingSearchCommand(command[1]);
                        break;
                    case "diff":
                        ProcessingDiffCommand(command[1], command[2]);
                        break;
                    case "mode":
                        break;
                    default: break;
                }
            }
        }
    }

    private void ProcessingSearchCommand(string aminoAcid)
    {
        aminoAcid = RLDecoding(aminoAcid);

        // can be empty
        var genericDataWithAminoAcid = commandExecute.CommandReadImplementation(aminoAcid);
    }

    private void ProcessingDiffCommand(string protein1, string protein2)
    {
        // if -1 => missing protein 1
        // if -2 => missing protein 2
        // if -3 => missing protein 1 and 2
        int difference = commandExecute.CommandDiffImplementation(protein1, protein2);
    }

    // TODO ProcessingModeCommand

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
