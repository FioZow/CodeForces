using System;
using System.Linq;

namespace ExamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var testsCount = uint.Parse(Console.ReadLine());

            for (int i = 0; i < testsCount; i++)
            {
                var productsCount = uint.Parse(Console.ReadLine());
                var prices = Console.ReadLine().Split(" ").Select(it => uint.Parse(it)).ToList();
                var group = prices.GroupBy(x => x);

                uint result = 0;

                foreach (var item in group)
                {
                    var count = (uint)item.Count();
                    uint saleProductsCount = 0;

                    while (count >= 3)
                    {
                        saleProductsCount++;
                        count -= 3;
                    }

                    result += item.Key * ((uint)item.Count() - saleProductsCount);
                }
                Console.WriteLine(result);
            }
        }
    }
}
