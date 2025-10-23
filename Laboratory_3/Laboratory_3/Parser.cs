namespace Laboratory_3
{
    public static class Parser
    {
        public static Text ReadAllText(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return new Text(text);
        }
    }
}
