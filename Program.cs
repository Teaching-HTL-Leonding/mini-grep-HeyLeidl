

if (args.Length <= 4)
{
    string path = args[0];
    string filemuster = args[1];
    string searchtext = args[2];
    string[] files = Directory.GetFiles(path, filemuster);
    int counter_for_files = 0, counter_for_lines = 0, counter_of_occurrences = 0;

    for (int i = 0; i < files.Length; i++)
    {
        string[] lines = File.ReadAllLines(files[i]);
        if (File.ReadAllText(files[i]).Contains(searchtext))
        {
            Console.WriteLine(files[i]);
            for (int j = 0; j < lines.Length; j++)
            {
                if (lines[j].Contains(searchtext))
                {
                    Console.WriteLine($"{j + 1}: " + $"{lines[j]}");
                    counter_of_occurrences += CountOccurrences(lines[j], searchtext);
                    counter_for_lines++;
                }
            }
        }
        counter_for_files++;
    }

    Console.WriteLine("SUMMARY: ");
    Console.WriteLine($"Number of found files: {counter_for_files}");
    Console.WriteLine($"Number of found lines: {counter_for_lines}");
    Console.WriteLine($"Number of found occurrences: {counter_of_occurrences}");
}

int CountOccurrences(string text, string searchtext)
{
    int counter = 0;
    for (int i = 0; i < text.Length; i++)
    {
        if (!(char.IsLetterOrDigit(text[i])))
        {
            text = text.Replace(text[i], ' ');
        }
    }
    string[] words = text.Split(' ');

    for (int i = 0; i < words.Length; i++)
    {
        if (words[i] == searchtext)
        {
            counter++;
        }
    }
    return counter;
}
