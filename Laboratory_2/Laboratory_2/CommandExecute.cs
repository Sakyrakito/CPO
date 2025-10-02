using System.Reflection.Metadata;

namespace Laboratory_2;

public class CommandExecute
{
    readonly List<GenericData> _data = new();

    public CommandExecute(string genericDataPath)
    {
        ReadAllGenericData(genericDataPath);
    }

    private void ReadAllGenericData(string genericDataPath)
    {
        using (StreamReader reader = new StreamReader(genericDataPath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                _data.Add(new GenericData(line.Split('\t')));
            }
        }
    }

    public List<GenericData> CommandReadImplementation(string aminoAcid)
    {
        var genericDataList = _data.Where(gd => gd.Amino_acids.Contains(aminoAcid)).ToList();
        return genericDataList;
    }

    public int CommandDiffImplementation(string protein1, string protein2)
    {
        int difference = 0;
        if (_data.All(gd => gd.Protein != protein1)) difference--; 
        if (_data.All(gd => gd.Protein != protein2)) difference -= 2;

        if (difference != 0)
            return difference;

        string aminoAcid1 = _data.First(gd => gd.Protein == protein1).Amino_acids;
        string aminoAcid2 = _data.First(gd => gd.Protein == protein2).Amino_acids;

        difference = Math.Abs(aminoAcid1.Length - aminoAcid2.Length);

        for (int i = 0; i < Math.Min(aminoAcid1.Length, aminoAcid2.Length); i++)
        {
            if (aminoAcid1[i] != aminoAcid2[i])
                difference++;
        }

        return difference;
    }

    public (char, int) CommandModeImplementation(string protein)
    {
        if (_data.All(gd => gd.Protein != protein))
            return ('Z', -1);

        string aminoAcid = _data.First(gd => gd.Protein == protein).Amino_acids;
        Dictionary<char, int> countChar = new Dictionary<char, int>();

        char maxChar = aminoAcid[0];
        for (int i = 0; i < aminoAcid.Length; i++)
        {
            if (!countChar.ContainsKey(aminoAcid[i]))
                countChar.Add(aminoAcid[i], 1);
            else
                countChar[aminoAcid[i]]++;

            if (countChar[aminoAcid[i]] > countChar[maxChar])
                maxChar = aminoAcid[i];
            else if (countChar[aminoAcid[i]] == countChar[maxChar] && aminoAcid[i] < maxChar)
                maxChar = aminoAcid[i];
        }

        return (maxChar, countChar[maxChar]);
    }
}
