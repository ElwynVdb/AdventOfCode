﻿using System;
using System.Collections.Generic;
using System.Linq;
using day_1;
using Microsoft.VisualBasic;

namespace advent
{
    public class Day4: Day
    {
        public static int[] givenNumbers = Array.ConvertAll("93,49,16,88,4,92,23,38,44,98,97,8,5,69,41,70,19,11,29,40,90,43,79,96,68,10,31,35,34,32,0,67,83,33,2,76,24,87,99,77,82,66,12,15,28,59,64,95,91,71,62,22,53,46,39,81,75,86,74,56,50,18,17,73,13,54,60,48,21,51,52,55,85,80,30,36,47,3,26,57,84,25,63,27,37,94,7,45,58,9,78,65,72,6,14,61,20,1,42,89".Split(","), input => int.Parse(input));

        public static String boards = "83 11 47 61 45\n30 74 73 14 66\n53 52 10 57 15\n64 50 54 28 87\n26 85 63 25 86\n\n72  4 62 30 49\n43 93 39 63 25\n18 70 44 77 38\n84  8 85  5 26\n54 50 40 75  2\n\n70 78 55 26 35\n75 44 80 15 34\n67 47 53 10 56\n73 46 27 38 13\n64 92 39 87 23\n\n24 66 11 44 51\n32 37 83 69 85\n46 59 14 99 76\n71 28 94 35 98\n16 40 74 80  6\n\n 1 55 42 59 70\n87 81 68 83 56\n12 21 20 49 84\n89 92 94  2 76\n 5 17 77  3 32\n\n66 98 10 53 78\n80 92 26 38 29\n46 34 22 51  8\n43 89 87 64 17\n63 86 84 62 15\n\n75 65 96 19 87\n12 51 97 68  8\n42 90 61 10 71\n69 48  7 15 26\n43 89 21 16 35\n\n64 92 83  2 48\n11 34 98 75 96\n21  6 54 78 68\n42 19 16 41  8\n24 58 45 81 49\n\n59 37 46  1 30\n51  6 10 44 82\n85  3 27 83 96\n48 81 56 34 55\n35 99 67 12 78\n\n14 49 41 82 78\n 8 70 29 72 32\n61 16 19 68 38\n93 46 48 42 31\n45 36 84 54 11\n\n96 14  1 71 91\n 3 89 59 27  2\n34 37  5 31  0\n22 44 98 43 32\n 6 66 95 40 46\n\n75 57 76 50 84\n32 59 35 12 86\n81 77 42 13 21\n91  3  9 44 96\n 4 52 23 18 37\n\n16 62 40  8 82\n43 70 29 63  9\n41 73 77 13 59\n44  0 49 53 76\n84 55 36 56 48\n\n81 62 35 65 43\n 6 84 67 44 48\n31 56 73 69 33\n66 92 40 77 55\n 4 70 97 88 13\n\n63  5 12 66 77\n68 74 15 84 16\n 1 45 72 54 42\n58 33 35 65 21\n73 60 67 10 95\n\n 0 25 16 42 45\n27 98 87 29  3\n62  6 88 19 95\n84 33 53 89 37\n46 38 97 96 77\n\n98 62  8 73 20\n81 83 51 55 21\n 4 13 70 60  1\n32 82 12 22 61\n79 40 92 76 36\n\n91 52 17 13 76\n25 79 88 90 87\n41 58 89 30 66\n56 49 69 35 61\n44 57 81 34 43\n\n69 88 87 72 84\n36 55 13 11 27\n47 40 34 99 38\n23 18 96 57 28\n41 67 26  6 54\n\n39 69 49 40 86\n 6 75 90 31 21\n82 15 48 37 88\n55 23  4  7 10\n68 81 87 56 73\n\n41 65 82 20 31\n42 22 88 70 75\n73 76 54 15 83\n67 99 46 28 72\n 9 51 57 96 38\n\n 3  1 15 13 79\n 7 94 77 86 30\n54 39  9  5 43\n66 34 92 87 88\n59 93 32 48 51\n\n98 21 19 76 97\n93 83  5 24 99\n14 80 85  7 92\n 8 53  1 78 72\n45 20  2 13  6\n\n51 28 54 62 42\n97 70 77 23 81\n15 67 33 55  0\n35 78 14 61  8\n26 13 99 56 24\n\n71 99  2 72 21\n22 54 30 38 41\n92 47 56 70 34\n28 90  0 67 78\n63 14 84 97 61\n\n86 81 85 21 65\n59 47 56 28 32\n89 54 44 71  1\n80 55 76 12 33\n13 11 31 92 88\n\n54 41  8 46 83\n35  2 23 15 52\n31 91 92 61 19\n25 17 98 53 22\n72 78 81 84 27\n\n61 72 95 50 49\n19 37 85 64 71\n78 18 59 54 67\n75 68 27 90  1\n 8 62  3 32 83\n\n 0 20 88 30 52\n87 13 73  3 79\n37 22 10 70 67\n61 48 81 40 54\n50 68 93  8 34\n\n88 39  9 36 15\n14 79  1 58 83\n 4 73 42 55 37\n 0 53 77 28  8\n18 92 21 25 62\n\n65 36 59 80 97\n 6 60  3 95 52\n20 10 78  1 46\n45 26 38 96 25\n37 85 19 98 75\n\n27 47 38 62 86\n16 35 87 46 74\n52 94 25  9  2\n61 88 51 90 68\n79 72  1 20 82\n\n 5 29  9 44 64\n89 15 78 56  2\n85 93 28 79 34\n87 16 21 59 49\n 8 39 71 57 75\n\n 0 64 99 62 28\n47  3 87 31  9\n70 10 97 24 91\n65 43 96 86 85\n35 88 25 67 83\n\n69 67  8 31 49\n57 22 83 56 79\n91 54 70 33 53\n68 47 84 80 35\n21  7 65  4 17\n\n 4  2 18 62 13\n74 31 60 59 16\n71 43 86 17 93\n70 81 50 53 64\n51 96 49  7 47\n\n51 96 12 23 18\n27  2 35 55 50\n92 44  4 49 85\n40 58  6 13 16\n98  5 48 74 57\n\n88  3 15 45 95\n59  2 58 98 77\n62 89 80 11 74\n10 49 48 72 76\n86 61 53 60 44\n\n77 85  1  3 76\n94 30 83  6 39\n80 92 24 31 46\n64 47 65  7 84\n23 86 79 82 34\n\n99  5  2 23 53\n78 79 55 96 84\n91 43 47 69 63\n80 29 94 14 32\n 1 18 90 28 68\n\n29 51 43 17  0\n 4 44 48 93 40\n52 11 75 50 88\n34 95 47 68 55\n84 54 19 12  5\n\n26 98 34 92 53\n80 69 68  5 71\n 1 30 61 15 56\n96 22 52 70 25\n93  7 36 18 55\n\n19 16  4 32 55\n61 66 67 50 88\n89 51 64 57 43\n87 31 49 85  9\n90 39 56 96 59\n\n25 59 57 10 52\n 8 50 28 71  3\n99 78 47 31 42\n 0 82 98 93  2\n89 81 55 76 13\n\n19 81 93 25 20\n87 70 42 38 44\n33 98 62 91 39\n49 80 47 56 28\n92 46  8 78 75\n\n70 86 32 10 83\n30 62 99 45 88\n 6  5 43 22 16\n57 48 49 18 68\n33 28 80 94  9\n\n85 65 83 59 44\n52 24 87 31 56\n17 94 73 43 58\n10 23 46 36 89\n53 28 63 62 70\n\n72  7 99 40 77\n68 71 12 19 97\n54 73 64 43 11\n44 29 58 75 78\n21  6 30 90 28\n\n97 32 21 48 25\n67 58 64  0  1\n50 49 27 70 43\n76 22 12 51 37\n93 20 62 36 26\n\n76 69 52  2 67\n13 18  1 62 81\n94 43 99 10 45\n17 55 19 44 78\n46  3 16 74 73\n\n23 17 66  2 78\n44 53 67 19 69\n94 43 85 34 14\n26 63 40  1 27\n95 48 20 72 64\n\n49 96 17 42 53\n 8 15 62  3 90\n 9 57 61 82 46\n95 44 75 27 23\n10  6 24 63 98\n\n80 35 65 55 37\n64 91 77  3 94\n46 24 97 87 78\n60  2 61 23 32\n51 92 59 73 25\n\n68  5 32 99 70\n18 43 96 63 52\n88  3 59 76 25\n65 48 72  2 24\n67 41 60 44 87\n\n12 48 72 86 93\n27 36 96 51 21\n 2 50 34 83  6\n49 65 32 42 87\n88 10 43 84 22\n\n78 70 44 10 80\n18 71 17 50 27\n12 46 88  6 91\n98  0 31 85 56\n92 53 72 77 28\n\n85 84  6 89 24\n15 41 21 92 71\n88 90 95 32 98\n46 60 35 38 17\n36 66 93 70 40\n\n54  5 41 59 76\n38 47 48 51 71\n80 96 39 85  0\n68 61 55 40 13\n78 94 99 19 30\n\n50  3 55 37 25\n16 59 48 52 13\n41 20 46 27 39\n90 80 30 84 93\n22 12 79 74  0\n\n16 97  4 58 80\n68 49  0 87 35\n88 63  1 36 74\n45 91 55 46 75\n22 17 43 19 71\n\n30 98 31 63 16\n62  6  3  9 67\n61 11 29 66 52\n80 97 42 72 76\n78 57 90 13 89\n\n40 22  8 11 43\n90 61 29 10 88\n69 86 74 26 70\n14 51 93 32 80\n84 75 81 72 16\n\n91 22 89 72 82\n63 58 80 42 45\n11 40 29 41 90\n17 16 62 14 35\n23  4 65 79  0\n\n32 76 30  8 90\n 0 89  1 95 48\n40 44 68 49 37\n35 26 81 51 21\n47 19 83 91 71\n\n 9 31 70 42 16\n82  4 84 54 45\n58 36 53 20 44\n26  5 69 90 52\n95 67 51  7 76\n\n 5 64 51 63  8\n80 22 85 35 16\n31 99 68 53 65\n58  2 32 83 59\n92 93 18 56 62\n\n32 94  9 68 79\n26 34  7  1  0\n95 56 69 29 20\n18 55 25 15 88\n54 97 61 51 10\n\n25  9  1 70 80\n14 75 58 30 81\n45 19  2 41 95\n93 21 74  7 59\n34 89 52 78 54\n\n81  1 61 92 51\n97 35  3  7 39\n76 62 32 26 90\n71 72 19 31 15\n45 57 82 14 24\n\n66  6 27 11 81\n40 60 48 75 91\n86 31 62 36 72\n54 76 25 44 74\n84 29 20 53 68\n\n80 33 97  7 51\n74 66  6 67 83\n76 68 87 90 91\n 2 53 49 31 82\n72 95 26 28 22\n\n33  1 93  2  8\n 7 19  6 51 47\n63 68 26 90 54\n59 22  9 46 28\n40 20 80 86 15\n\n47  5 23 64 31\n54 44 51 14 21\n24 25 93 62  0\n41 15 56 91 40\n48 17 69 11 81\n\n59 27 47 82 44\n78 89 34  1 23\n31 91 35 30 52\n48 15 32 43  5\n42 41 12 53 77\n\n83  8 74 12  4\n45 56 22 68 50\n99  2 55 62 90\n36 14  3 33 93\n43 26 85 96 61\n\n13 33 85 32 84\n41 66 48  9 11\n70 80 45 82 34\n74 94 67 58 98\n89  8 39 51 64\n\n20 23 32 57 52\n17  7 86 90 75\n78 44 43 41 12\n29 92  0 35 48\n15 61 42 74 21\n\n76 92 73 16  2\n78 18 91 86 51\n70 66 11 12 79\n44 28 49 56 80\n64 74 67 46 20\n\n56 87 96 62 53\n63  7 47 39 66\n61 78 23 33 10\n65 76 19  3 94\n25 84 90 68 79\n\n33 79 70 88 61\n99 23 76 37 66\n16 81 67 46 49\n91 73 83 44 18\n28 59 85 55 21\n\n15 44 70 23 43\n94 48  8 77 28\n53 63 17 83 69\n25 74 40 11 35\n78 36 31 85 84\n\n73 80 31 90 20\n53 60  1 87 33\n51 89 47 32 22\n71 15 55 26  5\n77 81 39 11 94\n\n 2 15 79 22 50\n63  8 66 53 13\n26  4 16 20 59\n47 93 80 77 38\n 7 52 92 74 99\n\n68 10 22 61  7\n50 63 93 27 54\n32 79 20 62 88\n13 77 64 89 65\n97 41 39 38 75\n\n81 29 64 14 80\n25 57 94 13 60\n58 33 63 98 42\n46 10 17 76 61\n 2  1 68 56 45\n\n49 23 82 10 56\n71 25 85 26 58\n65 37 88  7  3\n34 80 66 63 74\n57 51 35 39 91\n\n35 48  3 22 38\n49 19 71 55 62\n34 96 69 32 58\n40 81 56 36 50\n15 52 46 53 90\n\n25  5 93 72 26\n88 84 75 87 34\n69 60 79 48 50\n27 73 33 55 47\n65 62 74 46  4\n\n86 82 78 17 16\n72 36 76 20 68\n69 95 58 37 80\n92 97 28 30  7\n 6 15  8 57 54\n\n50 64 61  0 66\n33 44 46 16 17\n85 67 76 30 28\n25 69 82 54  2\n24 96  5 68  6\n\n 7 98 31  2 11\n13 92  4 72 73\n62 29 15 47 40\n21 90 57 89 76\n81 66 88 12 82\n\n37 45 19 78 73\n82 68 96 26 51\n35 28 13 12 98\n40 47 59 10 18\n 3 88  6 69 29\n\n62 45  2 46 90\n52 25 50 13  1\n64 47 73 54 79\n33 36 92 15 77\n28  4 83 63  5\n\n72 63 57 95 16\n17 70 48 23 39\n65 96 87 85 33\n75 81 82 64 19\n80 66  5 58 83\n\n19  9 40 16 33\n51 87 66 59 49\n94 61 83 81  2\n84 27 63 54 10\n 8 95 88 42  6\n\n 4 37 62 80 10\n35 98 27 93 69\n96 43 65 90  1\n23 60 53 44 99\n28 38 68 17 71\n\n61 45 93 95 91\n35 43 76 98 41\n89 21 87 23 99\n 8 81 58 12  0\n32 24 15 70 96\n\n91 59 26 69 61\n16  2 45 34 66\n95 62 78 82 12\n98 41 30 49 50\n32 22 53  8  7\n\n94 50 23 64 46\n90 19 68 93 76\n63 49  9 44 89\n83 88 36 55  6\n22 14 85 58 70\n\n89 97 86 21  4\n57 29 17 46 22\n25 10 49 74 63\n24 23 93 56 11\n37 48 82 55 88";
       
       // This is how I have to fix the input, as it never formats correctly on my end.
        public static String[] temp = boards.Replace("  ", " ").Replace("\n ", "\n").Replace("\n\n", "s")
            .Replace("\n", " ")
            .Split("s");
        
        // First winning
        public void PuzzleOne()
        {
            List<BingoBoard> boardsArray = new List<BingoBoard>();

            for (int x = 0; x < temp.Length; x++)
            {
                boardsArray.Add(new BingoBoard().Fill(temp[x].Split(" ")));
            }

            BingoBoard firstWinning = null;
            int lastNumber = 0;
            
            foreach (int number in givenNumbers)
            {
                foreach (BingoBoard board in boardsArray)
                {
                    board.CheckAndMark(number);

                    if (board.CheckWon())
                    {
                        firstWinning = board;
                        lastNumber = number;
                        break;
                    }
                }
                if(firstWinning != null) break;
            }

            Console.WriteLine($"Last number: {lastNumber}");
            Console.WriteLine($"Unmarked count: {firstWinning.CountUnmarked()}");
            Console.WriteLine($"Total: {firstWinning.CountUnmarked() * lastNumber}");
        }

        // Last winning
        public void PuzzleTwo()
        {
            List<BingoBoard> boardsArray = new List<BingoBoard>();
            for (int x = 0; x < temp.Length; x++)
            {
                boardsArray.Add(new BingoBoard().Fill(temp[x].Split(" ")));
            }

            BingoBoard lastBoard = null;
            int lastNumber = 0;
            
            foreach (int number in givenNumbers)
            {
                foreach (BingoBoard board in boardsArray)
                {
                    if (board.HasWon) continue;

                    board.CheckAndMark(number);

                    if (board.CheckWon())
                    {
                        if (BingoBoard.AreAllBoardsWon(boardsArray))
                        {
                            lastBoard = board;
                            lastNumber = number;
                            break;
                        }
                    }
                }
                if(lastBoard != null) break;
            }

            Console.WriteLine($"Last number: {lastNumber}");
            Console.WriteLine($"Unmarked count: {lastBoard.CountUnmarked()}");
            Console.WriteLine($"Total: {lastBoard.CountUnmarked() * lastNumber}");
        }

        public class BingoBoard
        {
            private readonly int[,] _numbers = new int[5,5];
            private readonly int[,] _markers = new int[5, 5];

            public bool HasWon;

            public BingoBoard Fill(String[] boardString)
            {
                int line = 0;
                for (int x = 0; x < 25; x++)
                {
                    if (x % 5 == 0 && x != 0) line++;
                    
                    _numbers[line, x % 5] = int.Parse(boardString[x]);
                    _markers[line, x % 5] = 0;
                }

                return this;
            }

            public void CheckAndMark(int number)
            {
                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 5; column++)
                    {
                        if (_numbers[row, column] == number)
                        {
                            AddMarker(row, column);
                        }
                    }
                }
            }

            private void AddMarker(int x, int y)
            {
                _markers[x, y] = 1;
            }

            public int CountUnmarked()
            {
                int count = 0;
                
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (_markers[x, y] != 1)
                        {
                            count += _numbers[x, y];
                        }
                    }
                }

                return count;
            }

            public bool CheckWon()
            {
                for (int row = 0; row < 5; row++)
                {
                    if (_markers[row, 0] == 1 && _markers[row, 1] == 1 && _markers[row, 2] == 1 && _markers[row, 3] == 1 && _markers[row, 4] == 1) HasWon = true;
                    if (_markers[0, row] == 1 && _markers[1, row] == 1 && _markers[2, row] == 1 && _markers[3, row] == 1 && _markers[4, row] == 1) HasWon = true;
                }

                return HasWon;
            }

            public static bool AreAllBoardsWon(List<BingoBoard> boards)
            {
                bool wasLast = false;
                foreach (BingoBoard boardCheck in boards)
                {
                    wasLast = boardCheck.HasWon;
                    if(!wasLast) break;
                }

                return wasLast;
            }
        }
    }
}