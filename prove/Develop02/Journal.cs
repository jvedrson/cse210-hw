using System;
using Newtonsoft.Json; // Library added

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        // Saving as JSON
        if (filename.EndsWith(".json"))
        {
            string output = JsonConvert.SerializeObject(_entries);
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(output);
            }
        }
        else
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date},{entry._promptText},{entry._entryText}");
                }
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (filename.EndsWith(".json"))
        {
            _entries.Clear();
            List<Entry> entriesLoaded = JsonConvert.DeserializeObject<List<Entry>>(File.ReadAllText(filename));
            foreach (Entry entry in entriesLoaded)
            {
                AddEntry(entry);
            }
        }
        else
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split(",");

                string date = parts[0];
                string promptText = parts[1];
                string entryText = parts[2];

                Entry entry = new Entry();
                entry._date = date;
                entry._promptText = promptText;
                entry._entryText = entryText;

                AddEntry(entry);
            }
        }
    }
}