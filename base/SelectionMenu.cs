using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using advent;
using advent.day3;

namespace day_1
{
    public class SelectionMenu
    {
        private static Dictionary<String, Day> _days = new();

        public static void CreateSelection()
        {
            addDay("Day 1 - Sonar Sweep", new Day1());
            addDay("Day 2 - Dive", new Day2());
            addDay("Day 3 - Binary Diagnostic", new Day3());
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Advent of Code - 2021");
            Console.WriteLine("-----------------------");
            
            int index = 0;

            foreach (var pair in _days)
            {
                Console.WriteLine($"{++index} - {pair.Key}");
            }

            Console.WriteLine("-----------------------");

            int selectedIndex;
            do
            {
                Console.Write("Which day would you like to select? ");
                int.TryParse(Console.ReadLine(), out selectedIndex);

                if (selectedIndex > _days.Count) selectedIndex = -1;
            } while (selectedIndex <= -1);

            Console.Clear();

            Day dayToDisplay = _days[_days.Keys.ElementAt(selectedIndex - 1)];

            Thread.Sleep(1);
            Console.WriteLine("Puzzle 1");
            Console.WriteLine("----------");
            dayToDisplay.PuzzleOne();
            Console.WriteLine("----------");
            Console.WriteLine("Puzzle 2");
            Console.WriteLine("----------");
            dayToDisplay.PuzzleTwo();            
            Console.WriteLine("----------");
        }

        public static void addDay(String desc, Day day)
        {
            _days.Add(desc, day);
        }
    }
}