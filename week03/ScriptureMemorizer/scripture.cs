using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text into words and add to list
        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        
        // Get list of words that are not yet hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // If no visible words left, exit early
        if (visibleWords.Count == 0)
        {
            return;
        }

        // Hide up to the specified number of random visible words
        for (int i = 0; i < numberToHide; i++)
        {
            if (visibleWords.Count == 0) break;

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        List<string> displayTextWords = new List<string>();
        foreach (Word word in _words)
        {
            displayTextWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} - {string.Join(" ", displayTextWords)}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}