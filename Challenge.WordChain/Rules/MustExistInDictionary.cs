using Challenge.WordChain.Dictionaries;

namespace Challenge.WordChain.Rules;

public class MustExistInDictionary : IRule
{
    private readonly IWordDictionary _dictionary;

    public MustExistInDictionary(IWordDictionary dictionary)
    {
        _dictionary = dictionary;
    }
    
    public bool IsValid(string start, string end)
    {
        return _dictionary.Find(start) && _dictionary.Find(end);
    }
}