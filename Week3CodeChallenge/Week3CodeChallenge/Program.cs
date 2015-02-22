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
            long maxLength = 0;
            int startingNumber = 0;
            long number;

            for (int i = 2; i <= 1000000; i++)
            {
                long chainLength = 1;
                number = i;

                while (number != 1)
                {
                    if ((number % 2) == 0)
                    {
                        number = number / 2;
                    }
                    else
                    {
                        number = number * 3 + 1;
                    }
                    chainLength++;
                }

                //Check if sequence is the best solution
                if (chainLength > maxLength)
                {
                   maxLength = chainLength;
                   startingNumber = i;
                }
            }
            return startingNumber;
        }

        public static long LongestCollatzSequence2()
        {

            List<List<int>> chainList = new List<List<int>>();
            List<int> firstChain = new List<int>();

            const int million = 1000000;

            //create the first chain
            int j = million;
            firstChain.Add(j);
            while (j > 1)
            {
                if (j % 2 == 0)
                {
                    j = j / 2;
                }
                else
                {
                    j = 3 * j + 1;
                }
                //add a ring in the chain
                firstChain.Add(j);
            }
            //add first chain at the top of the list
            chainList.Add(firstChain);

            for (int i = million - 1; i > 1; i--)
            {
                bool chainAdded = false;

                List<int> subList = new List<int>();

                //create the chain until 1
                int z = i;
                while (z > 1)
                {
                    //if the chain for this number has not been created yet
                    if (AlreadyInChain(chainList, ref subList, z) == false)
                    {
                        //add the new number in the chain
                        subList.Add(z);

                        if (z % 2 == 0)
                        {
                            z = z / 2;
                        }
                        else
                        {
                            z = 3 * z + 1;
                        }

                    }
                    else
                    {
                        chainAdded = true;
                        break;
                    }
                }
                chainList.Add(subList);

                //if (chainAdded == false)
                //{
                //    //add the chain to the list of chain
                //    chainList.Add(subList);
                //}

            }

            return chainList.Max(x => x.Count);
            
        }

        /// <summary>
        /// Concatenate 2 chains
        /// </summary>
        /// <param name="list">The list of chains</param>
        /// <param name="subList">The chain to concatenate</param>
        /// <param name="number">The number to search in the previous chains</param>
        /// <returns>True if has concatenated two chain</returns>
        public static bool AlreadyInChain(List<List<int>> list, ref List<int> subList, int number)
        {
            int indexCurrentList = 0;
            foreach (List<int> sub in list)
            {
                //check if the list already contains the number
                int indexInSubList = sub.IndexOf(number);
                if (indexInSubList != -1)
                {
                    List<int> tempList = list[indexCurrentList].Skip(indexInSubList).ToList();

                    //if it's the first number of the current chain
                    if (subList.Count == 0)
                    {
                        subList.AddRange(tempList);
                    }
                    else
                    {
                        //concatenate the chain list 
                        //list[indexCurrentList+1].Concat(list[indexCurrentList].Skip(indexInSubList).ToList());
                        subList = subList.Concat(list[indexCurrentList].Skip(indexInSubList).ToList()).ToList();
                    }
                    return true;
                }

                indexCurrentList++;
            }
            return false;
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
                for (int j = checkThisNumber/2; j > 1; j--)
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
