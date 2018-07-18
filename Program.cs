using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application11
{
    private static bool[] SetPrimes(int max)
    {
        bool[] localPrimes = new bool[max + 1];
        for (int i = 2; i <= max; i++)
        {
            localPrimes[i] = true;
        }
        for (int i = 2; i <= Math.Sqrt(max); i++)
        {
            if (localPrimes[i])
            {
                for (int j = i * i; j <= max; j += i)
                {
                    localPrimes[j] = false;
                }
            }
        }
        return localPrimes;
    }

    class Program
    {
        static void Main(string[] args)
        {
             int max = 0;
        int maxCount = 1;
        List<int> primes = new List<int>();
        Stopwatch sw = Stopwatch.StartNew();
        bool[] allNumbers = SetPrimes(1000000);
        for (int i = 0; i < allNumbers.Length; i++)
        {
            if (allNumbers[i])
            {
                primes.Add(i);
            }
        }
        foreach (int prime in primes)
        {
            int startingIndex = 0;
            while (primes[startingIndex] < prime/maxCount)
            {
                int n = prime;
                int j = startingIndex;
                int sum = 0;
                int count = 0;
                while (n > 0)
                {
                    sum += primes[j];
                    n -= primes[j];
                    j++;
                    count++;
                }
                if (sum == prime)
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        max = prime;
                    }
                }
                startingIndex++;
            }
        }
        sw.Stop();
        Console.WriteLine(max);
        Console.WriteLine($"Time to calculate : {sw.ElapsedMilliseconds}");
        Console.ReadKey();
        }
    }
}
