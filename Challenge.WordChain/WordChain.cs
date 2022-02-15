using Challenge.WordChain.Dictionaries;
using Challenge.WordChain.Rules;
using Microsoft.VisualBasic;

namespace Challenge.WordChain;

public class WordChain
{
    private ICollection<IRule> _rules = new List<IRule>();

    private IWordDictionary _dictionary;

    public WordChain(IWordDictionary dictionary)
    {
        this._dictionary = dictionary;
    }
    
    public void AddRule(IRule rule) => this._rules.Add(rule);
    
    private bool IsValid(string start, string end)
    {
        foreach (var rule in _rules)
            if (!rule.IsValid(start, end))
                return false;

        return true;
    }

    public void Play()
    {
        Console.WriteLine("Start Word:");
        var start = Console.ReadLine().ToLower();

        Console.WriteLine("End Word:");
        var end = Console.ReadLine().ToLower();
        
        if (!this.IsValid(start, end))
            this.Retry();

        var stack = new Stack<string>();

        Recurse(start, end, stack);
        
        Console.WriteLine("Results chain:");
        Console.WriteLine(string.Join(',', stack.ToArray()));
    }

    private bool Recurse(string from, string to, Stack<string> stack)
    {
        stack.Push(from);

        if (from == to) return true;

        foreach (var word in _dictionary.Words)
        {
            if (word.Length == from.Length && _dictionary.CountDifferences(from, word) == 1 && !stack.Contains(word))
            {
                if (Recurse(word, to, stack)) return true;

                stack.Pop();
            }
        }
        
        return false;
    }

    private void Retry()
    {
        Console.WriteLine("Oops! Please enter valid start and end words to try again...");
        
        this.Play();
    }
}

