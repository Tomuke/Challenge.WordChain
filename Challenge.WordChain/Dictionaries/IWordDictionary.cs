namespace Challenge.WordChain.Dictionaries;

public interface IWordDictionary
{
    string[] Words { get; }
     
    void Load();

    bool Find(string word)
    {
        foreach (var w in this.Words) {
            if ( w == word) return true;
        }
        return false;
    }
    
    int CountDifferences(string from, string to)
    {
        int differences = 0;
    
        for(int i = 0; i < from.Length; i++)
            if (from[i] != to[i])
                differences++;

        return differences;
    }

}