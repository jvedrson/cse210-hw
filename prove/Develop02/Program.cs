using System;

/*
Exceeding Requirements

- The Newtonsoft.Json library was used to serialize and deserialize the objects to save and load files with .json extension
- Added a new field in the entries: _time
- Files with .csv extension can be saved and loaded
*/

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();

        bool write = false;
        bool display = false;
        bool loadFile = false;
        bool saveFile = false;
        bool quit = false;
        bool isValidOption = false;

        Console.WriteLine("Welcome to the Journal Program:");

        while (!quit)
        {
            int userOptionInput = Menu();
            isValidOption = userOptionInput >= 1 && userOptionInput <= 5;

            if (isValidOption)
            {
                write = userOptionInput == 1;
                display = userOptionInput == 2;
                loadFile = userOptionInput == 3;
                saveFile = userOptionInput == 4;
                quit = userOptionInput == 5;

                if (!quit)
                {
                    if (write)
                    {
                        DateTime theCurrentTime = DateTime.Now;
                        string date = theCurrentTime.ToShortDateString();
                        string time = theCurrentTime.ToShortTimeString();
                        string promptGenerated = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"{promptGenerated}");
                        Console.Write("> ");
                        string entryText = Console.ReadLine();

                        Entry entry = new Entry();
                        entry._date = date;
                        entry._time = time;
                        entry._promptText = promptGenerated;
                        entry._entryText = entryText;

                        journal.AddEntry(entry);
                    }
                    else if (display)
                    {
                        journal.DisplayAll();
                    }
                    else if (loadFile || saveFile)
                    {
                        Console.WriteLine("What is the filename?");
                        Console.Write("> ");
                        string filename = Console.ReadLine();

                        if (loadFile)
                        {
                            journal.LoadFromFile(filename);
                        }
                        else
                        {
                            journal.SaveToFile(filename);
                        }
                    }
                }
            }
        }

    }

    static int Menu()
    {
        Console.WriteLine("Please select one of the following");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");

        return Convert.ToInt32(Console.ReadLine()); ;
    }
}