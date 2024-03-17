using System;

public class Entry
{
    public string _date;
    public string _time;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} {_time} - Prompt: {_promptText}");        
        Console.WriteLine($"{_entryText}\n");
    }
}