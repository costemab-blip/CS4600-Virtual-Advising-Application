
public class InputReader
{
    public static List<string> getWords(string filePath)
    {
        List<string> wordList = new List<string>();       
        var linesRead = File.ReadLines(filePath);
    
        foreach (var line in linesRead)
        {
            string[] words = line.Split([' ', '\n','\r'],
            StringSplitOptions.RemoveEmptyEntries);
            foreach ( var word in words)
            {
                wordList.Add(word);
            }
        }
        return wordList;
    }
}

