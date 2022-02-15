namespace Challenge.WordChain.Dictionaries;

public class LocalDictionary : IWordDictionary
{
    public LocalDictionary()
    {
        this.Load();
    }

    public void Load()
    {
        this.Words = File.ReadAllLines("Assets/dictionary.txt");
    }
    
    public string[] Words { get; private set; }

    public string[] WordsWithLengthOf(int length) => this.Words.Where(x => x.Length == length).ToArray();
}