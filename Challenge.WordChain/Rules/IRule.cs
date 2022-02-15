namespace Challenge.WordChain.Rules;

public interface IRule
{
    bool IsValid(string start, string end);
}