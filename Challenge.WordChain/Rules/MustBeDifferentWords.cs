namespace Challenge.WordChain.Rules;

public class MustBeDifferentWords : IRule
{
    public bool IsValid(string start, string end)
    {
        return start != end;
    }
}