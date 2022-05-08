using System;
using System.Linq;

namespace Summator
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            for(int i = 0; i < count; i++)
            {
                var numbers = Console.ReadLine().Split(" ").Select(it => int.Parse(it)).ToArray();
                Console.WriteLine(numbers.Sum());
            }
        }
    }
}
