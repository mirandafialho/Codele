namespace Codele.Lib;

public class Guess
{
    public const int MAX_WORD_LENGTH = 5;
    public string Word { get; set; }
    public List<(char, LetterStatus)>? GuessStatus;

    public Guess(string word)
    {
        this.Word = word;
    }

    public void GetGuessStatuses(string answer)
    {
        if (string.IsNullOrEmpty(answer))
        {
            return;
        }

        GuessStatus = new();

        for (int index = 0; index < MAX_WORD_LENGTH; index++)
        {
            char letter = Word[index];
            bool isDuplicateInAnswer = answer.Count(x => x == letter) > 1;

            if ((GuessStatus.Contains((letter, LetterStatus.Correct)) || GuessStatus.Contains((letter, LetterStatus.IncorrectPosition))) && !isDuplicateInAnswer)
            {
                GuessStatus.Add((letter, LetterStatus.Incorrect));
            }
            else
            {
                if (Word[index] == answer[index]) GuessStatus.Add((letter, LetterStatus.Correct));
                else if (answer.Contains(letter)) GuessStatus.Add((letter, LetterStatus.IncorrectPosition));
                else GuessStatus.Add((letter, LetterStatus.Incorrect));
            }
        }

    }

    public bool IsWinningGuess(string answer)
    {
        if (!string.IsNullOrEmpty(Word))
        {
            if (Word.Equals(answer)) return true;
            return false;
        }
        return false;
    }
}
