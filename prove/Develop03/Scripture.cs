using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();



    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Trim().Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random randomGenerator = new Random();
        int count = 0;

        while (!IsCompletelyHidden() && count < numberToHide)
        {
            int idx = randomGenerator.Next(0, _words.Count);
            if (!_words[idx].IsHidden())
            {
                _words[idx].Hide();
                count++;
            }
        }
    }

    public string GetDisplayText()
    {
        string textFormatted = "";
        foreach (Word word in _words)
        {
            textFormatted = $"{textFormatted} {word.GetDisplayText()}";
        }
        return $"{_reference.GetDisplayText()}{textFormatted}";
    }

    public bool IsCompletelyHidden()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                count++;
            }
        }
        return count == 0;
    }

}