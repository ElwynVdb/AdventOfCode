using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace advent
{
    public class Day6 : Day
    {
        private List<int> input = new(Array.ConvertAll("4,3,4,5,2,1,1,5,5,3,3,1,5,1,4,2,2,3,1,5,1,4,1,2,3,4,1,4,1,5,2,1,1,3,3,5,1,1,1,1,4,5,1,2,1,2,1,1,1,5,3,3,1,1,1,1,2,4,2,1,2,3,2,5,3,5,3,1,5,4,5,4,4,4,1,1,2,1,3,1,1,4,2,1,2,1,2,5,4,2,4,2,2,4,2,2,5,1,2,1,2,1,4,4,4,3,2,1,2,4,3,5,1,1,3,4,2,3,3,5,3,1,4,1,1,1,1,2,3,2,1,1,5,5,1,5,2,1,4,4,4,3,2,2,1,2,1,5,1,4,4,1,1,4,1,4,2,4,3,1,4,1,4,2,1,5,1,1,1,3,2,4,1,1,4,1,4,3,1,5,3,3,3,4,1,1,3,1,3,4,1,4,5,1,4,1,2,2,1,3,3,5,3,2,5,1,1,5,1,5,1,4,4,3,1,5,5,2,2,4,1,1,2,1,2,1,4,3,5,5,2,3,4,1,4,2,4,4,1,4,1,1,4,2,4,1,2,1,1,1,1,1,1,3,1,3,3,1,1,1,1,3,2,3,5,4,2,4,3,1,5,3,1,1,1,2,1,4,4,5,1,5,1,1,1,2,2,4,1,4,5,2,4,5,2,2,2,5,4,4".Split(","), s => int.Parse(s)));
        
        public void PuzzleOne()
        {
            Console.WriteLine($"Answer: {CountLanternFish(input,80)}");
        }

        public void PuzzleTwo()
        {
            Console.WriteLine($"Answer: {CountLanternFish(input,256)}");
        }

        private long CountLanternFish(List<int> initial, int days)
        {
            long[] differentAges = new long[9];
            
            // Initialize the count of given ages
            foreach (int age in initial)
            {
                differentAges[age]++;
            }

            for (int day = 0; day < days; day++)
            {
                // Get amount of 0, ready to give birth
                long first = differentAges[0];

                // shift array, bring age 1 to age 0
                for (int age = 0; age < 8; age++)
                {
                    differentAges[age] = differentAges[age + 1];
                }
                
                // Add the ready to give birth amount to the reset (6)
                differentAges[6] += first;
                
                // Add the newborns created from (first) which were ready to give birth
                differentAges[8] = first;
            }

            return differentAges.Sum();
        } 
    }
}