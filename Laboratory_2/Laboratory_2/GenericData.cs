namespace Laboratory_2;

public struct GenericData
{
    public readonly string Protein;
    public readonly string Organizm;
    public readonly string Amino_acids;

    public GenericData(string[] proteinInfo)
    {
        Protein = proteinInfo[0];
        Organizm = proteinInfo[1];
        Amino_acids = proteinInfo[2];
    }

    public override string ToString() =>
        $"{Protein}\t{Organizm}\t{Amino_acids}";
}
