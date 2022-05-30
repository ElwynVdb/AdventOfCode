using System;
using System.Linq;

namespace advent
{
    public class Day8 : Day
    {
        public static String input =
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb |\nfdgacbe cefdb cefbgd gcbe\nedbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec |\nfcgedb cgb dgebacf gc\nfgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef |\ncg cg fdcagb cbg\nfbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega |\nefabcd cedba gadfec cb\naecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga |\ngecf egdcabf bgf bfgea\nfgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf |\ngebdcfa ecba ca fadegcb\ndbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf |\ncefg dcbef fcge gbcadfe\nbdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd |\ned bcgafe cdgba cbgef\negadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg |\ngbdfcae bgc cg cgb\ngcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc |\nfgae cfgab fg bagce"
                .Replace("|\n", "|");

        public void PuzzleOne()
        {
            int counter = 0;

            foreach (string output in input.Split("\n"))
            {
                foreach (string digitPieces in output.Split("|")[1].Split(" "))
                {
                    int number = new SevenSegmentNumber().DecodeByCounting(digitPieces).number;
                    if (number > 0) counter++;
                }
            }

            Console.WriteLine(counter);
        }

        public void PuzzleTwo()
        {
            int counter = 0;

            foreach (string output in input.Split("\n"))
            {
                int number = new FourDigitCounter().Read(output.Split("|")[1].Split(" ")).GetDisplayNumber;
                counter += number;
            }

            Console.WriteLine(counter);
        }

        public class SevenSegmentNumber
        {
            private String[] _lookup =
                {"cagedb", "ab", "gcdfa", "fbcad", "eafb", "cdfbe", "cdfgeb", "dab", "acedgfb", "cefabd"};

            public int number;

            public SevenSegmentNumber Decode(String input)
            {
                char[] inputSegments = input.ToCharArray();

                DecodeByCounting(input);

                if (number <= 0)
                {
                    char[] inputArray = input.ToCharArray();
                    Array.Sort(inputArray);
                    
                    switch (input.Length)
                    {
                      /*  case 5:
                             if (inputArray[0] == 'b' && inputArray[4] == 'g' || inputArray[2] == 'c') number = 5;
                             else number = 3;
                             break;
                         case 6:
                             if (inputArray[0] == 'b' && inputArray[1] == 'c' || inputArray[3] == 'd') number = 9;
                             else if (inputArray[2] == 'c' || inputArray[2] == 'd') number = 6;
                             else number = 0;
                             break;*/
                    }
                }

                return this;
            }

            public SevenSegmentNumber DecodeByCounting(String input)
            {
                switch (input.Length)
                {
                    case 2:
                        number = 1;
                        break;
                    case 4:
                        number = 4;
                        break;
                    case 3:
                        number = 7;
                        break;
                    case 7:
                        number = 8;
                        break;
                }

                return this;
            }
        }

        public class FourDigitCounter
        {
            private SevenSegmentNumber[] Numbers = new SevenSegmentNumber[4];
            private String displayNumber = "";

            public FourDigitCounter Read(String[] segments)
            {
                for (int x = 0; x < 4; x++)
                {
                    Numbers[x] = new SevenSegmentNumber().Decode(segments[x]);
                }

                UpdateDisplayNumber();

                for (int y = 0; y < segments.Length; y++)
                {
                    Console.Write(segments[y] + " ");
                }

                Console.WriteLine(displayNumber);

                return this;
            }

            private void UpdateDisplayNumber()
            {
                displayNumber = "";

                foreach (SevenSegmentNumber segmentNumber in Numbers)
                {
                    displayNumber += segmentNumber.number.ToString();
                }
            }

            public int GetDisplayNumber => int.Parse(displayNumber);
        }
    }
}
