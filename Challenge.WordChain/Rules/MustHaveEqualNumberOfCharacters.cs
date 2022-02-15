namespace Challenge.WordChain.Rules;

public class MustHaveEqualNumberOfCharacters : IRule
{
    public bool IsValid(string start, string end)
    {
        return start.Length == end.Length;
    }
}