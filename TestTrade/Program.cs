using TestTrade;

string[] content =
    {
        "First|Last|Password|Email|Credit",
        "Joshua|Wagoner|qwerty|josh@email.com|Drachma",
        "Jackalene|Wagoner|123|jackie@email.com|Roses"
    };

string path = "C:\\Users\\JnJ Wagoner\\Desktop\\Database.csv";

FileOperations.WriteFile(path, content);
FileOperations.ReadFile(path);
Console.ReadKey();
