using Challenge.WordChain;
using Challenge.WordChain.Dictionaries;
using Challenge.WordChain.Rules;

var dictionary = new LocalDictionary();

var game = new WordChain(dictionary);

game.AddRule(new MustBeDifferentWords());
game.AddRule(new MustHaveEqualNumberOfCharacters());
game.AddRule(new MustExistInDictionary(dictionary));

game.Play();











    
    



