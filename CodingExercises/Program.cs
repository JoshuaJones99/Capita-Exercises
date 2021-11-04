using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Problem 1
            int x = LongestSequence(new int[] {1, 2, 1, 1, 0, 3, 1, 0, 0, 2, 4, 1, 0, 0, 0, 0, 2, 1, 0, 3, 1, 0, 0, 0, 6, 1, 3, 0, 0, 0});
            Console.WriteLine(x);
            //Problem 2
            List<string> anagram = Anagrams("parts,traps,arts,rats,starts,tarts,rat,art,tar,tars,stars,stray");
            anagram.ForEach(i => Console.WriteLine(i));
            //Problem 3
            Stars();
            //Problem 4
            StarsDiamond();
            //Problem 5
            StringReversal("Hello World");
            //Problem 6
            Palindrome("madam");
            Palindrome("step on no pets");
            Palindrome("book");
            //Problem 7
            Console.WriteLine(SumOfDigits("123"));
            //Problem 8
            Tuple<int,int> prob8 = TwoSums(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
            Console.WriteLine(prob8);
            //Problem 9
            int prob9 = Prime(5);
            Console.WriteLine("5rd Prime is {0}", prob9);
            //Problem 10
            int prob10 = NextPrime(15);
            Console.WriteLine(prob10);

            Console.ReadLine();
        }

        /* Problem 1 - Longest Sequence
         * Returns longest sequence of zeros (0) in an array of integers
         */
        static int LongestSequence(int[] seq)
        {
            int longest = 0;
            int count = 0;
            foreach (int x in seq)
            { 
                if (x == 0)
                {
                    count++;
                }
                else
                {
                    if (count >= longest)
                    {
                        longest = count;
                    }
                    count = 0;
                }
            }
            return longest;
        }

        /* Problem 2 - Anagrams
         * Return anagrams in argument words of the key word 'star'
         */
        static List<string> Anagrams(string words)
        {
            string keyWord = "star";
            var anagram = new List<string>();
            string[] wordsList = words.Split(',');
            for (int i = 0; i < wordsList.Length; i++)
            {
                int count = 0;
                foreach (char c in keyWord)
                {
                    if (wordsList[i].Contains(c))
                    {
                        count++; 
                    }
                }
                if (count == 4 && wordsList[i].Length == 4)
                {
                    anagram.Add(wordsList[i]);
                }
            }

            return anagram;
        }

        /* Problem 3 - Stars
         * Print star pattern onto screen
         */
        static void Stars()
        {
            int height = 5;
            for(int i = 1; i < height+1; i++)
            {
                for (int j = i; j < height+1; j++) Console.Write(' ');
                for (int j = 0; j < 2 * i - 1; j++) Console.Write('*');
                Console.WriteLine();
            }
        }

        /* Problem 4 - Stars (Diamond)
         * Print star (Diamond) pattern onto screen
         */
        static void StarsDiamond()
        {
            int peak = 5;
            for (int i = 1; i < peak+1; i++)
            {
                for (int j = i; j < peak + 1; j++) Console.Write(' ');
                for (int j = 0; j < 2 * i - 1; j++) Console.Write('*');
                Console.WriteLine();
            }
            for (int i = peak-1; i > 0; i--)
            {
                for (int j = 0; j < peak - i + 1; j++) Console.Write(' ');
                for (int j = 0; j < 2 * i - 1; j++) Console.Write('*');
                Console.WriteLine();
            }
        }

        /* Problem 5 - String Reversal
         * Print out a string in reverse
         */
        static void StringReversal(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(new String(chars));
        }

        /* Problem 6 - Palindrome
         * Write an algorithm to find a palindrome
         * Test case: step on no pets (palindrome)
         *          : madam           (no palindrome)
         */
        static void Palindrome(string input)
        {
            // Odd case
            bool palindrome = true;
            char[] chars = input.ToCharArray();
            if (chars.Length % 2 == 1)
            {
                for(int i = 0; i < (chars.Length - 1) / 2; i++)
                {
                    if (chars[i] != chars[chars.Length - i - 1]) palindrome = false;
                }
            }
            // Even case
            else
            {
                for(int i = 0; i < chars.Length / 2; i++)
                {
                    if (chars[i] != chars[chars.Length - i - 1]) palindrome = false;
                }
            }

            if (palindrome) Console.WriteLine("Palindrome");
            else Console.WriteLine("Not Palindrome");

        }

        /* Problem 7 - Sum of digits
         * Write an algorithm to sum the digits of a number
         */
        static int SumOfDigits(string input)
        {
            var digits = input.ToCharArray();
            int sum = 0;
            foreach(char x in digits) sum += (int)Char.GetNumericValue(x);
            return sum;
        }

        /* Problem 8 - TwoSums
         * Finds indices of pairs in argument 'input' which sums to 'target'
         */
        static Tuple<int,int> TwoSums(List<int> input, int target)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[i] + input[j] == target)
                    {
                        return (Tuple.Create(i, j));
                    }
                }
            }
            return (Tuple.Create(-1, -1));
        }

        /* Problem 9 - Prime at Nth position
         * Return the prime number at position N in the list of primes
         */
        static int Prime(int N)
        {
            List<int> primes = new List<int>();
            int i = 2;
            while (primes.Count < N-1)
            {
                if (checkPrime(i)) primes.Add(i);
                i++;
            }
            return primes.Last();
        }

        /* Problem 10 - Next prime number
         * Return prime number after given prime
         */
        static int NextPrime(int prime)
        {
            int i = prime + 1;
            while (!checkPrime(i)) i++;
            return i;
        }

        // Helper function for Prime and NextPrime
        static bool checkPrime(int x)
        {
            if (x % 2 == 0) return false;
            for (int j = 3; j <= (int)Math.Floor(Math.Sqrt(x)); j += 2)
            {
                if (x % j == 0) return false;
            }
            return true;
        }
    }
}
