using System;
using System.Collections.Generic;
using System.Linq;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestCollatzSequence());
            Console.ReadKey();
        }
        /// <summary>
        /// A function that calculates the starting value of the longest Collatz sequence.
        /// This function will start at 1 million and look at which value generates the
        /// longest sequence.
        /// </summary>
        /// <returns>Starting value of the longest sequence</returns>
        public static long LongestCollatzSequence()
        {
            long number, maxLength = 0;
            int startingNumber = 0;
            
            for (int i = 2; i <= 1000000; i++)
            {
                long chainLength = 1;
                number = i;

                while (number != 1)
                {
                    if (number % 2 == 0)
                    {
                        number = number / 2;
                    }
                    else
                    {
                        number = number * 3 + 1;
                    }
                    chainLength++;
                }

                //If the current chain is the longest so far
                if (chainLength > maxLength)
                {
                   maxLength = chainLength;
                   startingNumber = i;
                }
            }
            return startingNumber;
        }

 
        /// <summary>
        /// A Function that adds up each even number in a Fibonacci Sequence until the maxValue
        /// then prints the sum of those numbers to the console
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns>The sum of every even number for the given number of Fibonacci digits</returns>
        public static long EvenFibonacciSequencer(long maxValue)
        {
            int f1=1;
            int f2=1;
            int fn = f1 + f2;
            long evenSum = 0;
            while (evenSum < maxValue)
            {
                f1 = f2;
                f2 = fn;
                
                if (fn % 2 == 0)
                {
                    if (evenSum + fn < maxValue)
                    {
                        evenSum += fn;
                    }
                    else return evenSum;                    
                }
                fn = f1 + f2;
            }
            return evenSum; 
        }

        /// <summary>
        /// Function that finds the n'th prime indicated by the parameter
        /// </summary>
        /// <param name="maxPrime"></param>
        /// <returns>The prime number which is the n'th found</returns>
        public static int FindNPrimes(int maxPrime)
        {
            bool isPrime=true;
            int primeFound=0;
            int checkThisNumber = 2;

            while (primeFound < maxPrime)
            {
                for ( int j = (int)Math.Sqrt(checkThisNumber); j > 1;j-- )
                {
                    isPrime = true;
                    if (checkThisNumber % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeFound++;
                }
                checkThisNumber++;
            }
            
            return --checkThisNumber; // Default return value, replace this
        }
    }
}
