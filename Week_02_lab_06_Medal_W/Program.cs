﻿using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a medal object
        Medal m1 = new Medal("Horace Gwynne", "Boxing", "Gold", 2012, true);

        // Print the object
        Console.WriteLine(m1);

        // Print only the name of the medal holder
        Console.WriteLine(m1.Name);

        // Create another object
        Medal m2 = new Medal("Michael Phelps", "Swimming", "Gold", 2012, false);

        // Print the updated m2
        Console.WriteLine(m2);

        // Create a list to store the medal objects
        List<Medal> medals = new List<Medal>() { m1, m2 };

        medals.Add(new Medal("Ryan Cochrane", "Swimming", "Silver", 2012, false));
        medals.Add(new Medal("Adam van Koeverden", "Canoeing", "Silver", 2012, false));
        medals.Add(new Medal("Rosie MacLennan", "Gymnastics", "Gold", 2012, false));
        medals.Add(new Medal("Christine Girard", "Weightlifting", "Bronze", 2012, false));
        medals.Add(new Medal("Charles Hamelin", "Short Track", "Gold", 2014, true));
        medals.Add(new Medal("Alexandre Bilodeau", "Freestyle skiing", "Gold", 2012, true));
        medals.Add(new Medal("Jennifer Jones", "Curling", "Gold", 2014, false));
        medals.Add(new Medal("Charle Cournoyer", "Short Track", "Bronze", 2014, false));
        medals.Add(new Medal("Mark McMorris", "Snowboarding", "Bronze", 2014, false));
        medals.Add(new Medal("Sidney Crosby ", "Ice Hockey", "Gold", 2014, false));
        medals.Add(new Medal("Brad Jacobs", "Curling", "Gold", 2014, false));
        medals.Add(new Medal("Ryan Fry", "Curling", "Gold", 2014, false));
        medals.Add(new Medal("Antoine Valois-Fortier", "Judo", "Bronze", 2012, false));
        medals.Add(new Medal("Brent Hayden", "Swimming", "Bronze", 2012, false));

        // Prints a numbered list of 16 medals
        Console.WriteLine("\n\nAll 16 medals");
        for (int i = 0; i < medals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {medals[i]}");
        }

        // Prints a numbered list of 16 names (ONLY)
        Console.WriteLine("\n\nAll 16 names");
        for (int i = 0; i < medals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {medals[i].Name}");
        }

        // Prints a numbered list of 9 gold medals
        Console.WriteLine("\n\nAll 9 gold medals");
        int goldCount = 0;
        for (int i = 0; i < medals.Count; i++)
        {
            if (medals[i].Color == MedalColor.Gold)
            {
                goldCount++;
                Console.WriteLine($"{goldCount}. {medals[i]}");
            }
        }

        // Prints a numbered list of 9 medals in 2012
        Console.WriteLine("\n\nAll 9 medals in 2012");
        int year2012Count = 0;
        for (int i = 0; i < medals.Count; i++)
        {
            if (medals[i].Year == 2012)
            {
                year2012Count++;
                Console.WriteLine($"{year2012Count}. {medals[i]}");
            }
        }

        // Prints a numbered list of 4 gold medals in 2012
        Console.WriteLine("\n\nAll 4 gold medals in 2012");
        int gold2012Count = 0;
        for (int i = 0; i < medals.Count; i++)
        {
            if (medals[i].Year == 2012 && medals[i].Color == MedalColor.Gold)
            {
                gold2012Count++;
                Console.WriteLine($"{gold2012Count}. {medals[i]}");
            }
        }

        // Prints a numbered list of 3 world record medals
        Console.WriteLine("\n\nAll 3 records");
        int recordCount = 0;
        for (int i = 0; i < medals.Count; i++)
        {
            if (medals[i].IsRecord)
            {
                recordCount++;
                Console.WriteLine($"{recordCount}. {medals[i]}");
            }
        }

        // Saving all the medals to file Medals.txt
        Console.WriteLine("\n\nSaving to file");
        using (StreamWriter writer = new StreamWriter("Medals.txt"))
        {
            foreach (Medal medal in medals)
            {
                writer.WriteLine(medal);
            }
        }
    }
}

// MedalColor Enum
public enum MedalColor
{
    Bronze,
    Silver,
    Gold
}

// Medal Class
public class Medal
{
    // Properties
    public string Name { get; }
    public string TheEvent { get; }
    public MedalColor Color { get; }
    public int Year { get; }
    public bool IsRecord { get; }

    // Constructor
    public Medal(string name, string theEvent, string color, int year, bool isRecord)
    {
        Name = name;
        TheEvent = theEvent;
        Color = Enum.Parse<MedalColor>(color, true);
        Year = year;
        IsRecord = isRecord;
    }

    // ToString() method
    public override string ToString()
    {
        string recordString = IsRecord ? "(R)" : "";
        return $"{Year} - {TheEvent}{recordString} {Name}({Color})";
    }
}
