using System;
using System.Linq;

namespace Test_B
{
    class Program
    {
        static void Main(string[] args)
        {
            var testsCount = ushort.Parse(Console.ReadLine());

            for (int i = 0; i < testsCount; i++)
            {
                var numbersCount = uint.Parse(Console.ReadLine());
                var numbers = Console.ReadLine().Split(" ").Select(it => uint.Parse(it)).ToArray();
                var pointer = new uint[numbersCount];
                FillPointer(pointer);
                var niceImportance = new uint[numbersCount];
                uint nice = 1;

                Sort(numbers, pointer);

                var index = 0;
                do
                {
                    var counter = 1;
                    for (int j = index + 1; j < numbersCount; j++)
                    {
                        if (numbers[j - 1] == numbers[j])
                        {
                            counter++;
                        }
                        else if (numbers[j - 1] == numbers[j] + 1)
                        {
                            do
                            {
                                counter++;
                                j++;
                                if (j == numbersCount)
                                    break;
                            }
                            while (numbers[j] == numbers[j - 1]);
                            break;
                        }
                        else { break; }
                    }

                    for(int j = index; j < index + counter; j++)
                    {
                        niceImportance[j] += nice;
                    }
                    nice++;
                    index += counter;
                }
                while (index < numbersCount);

                Sort(pointer, niceImportance);
                Array.Reverse(niceImportance);

                PrintArray(niceImportance);
            }
        }

        private static void PrintArray(uint[] numbers)
        {
            foreach(int i in numbers)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public static void Sort(uint[] array, uint[] pointer)
        {
            var length = array.Length;

            for(int i = 0; i < length - 1; i++)
            {
                for(int j = 1; j < length - i; j++)
                {
                    if (array[j - 1] < array[j])
                    {
                        var temp1 = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp1;
                        
                        var temp2 = pointer[j - 1];
                        pointer[j - 1] = pointer[j];
                        pointer[j] = temp2;
                    }
                }
            }
        }

        public static void FillPointer(uint[] pointer)
        {
            for(uint i = 0; i < pointer.Length; i++)
            {
                pointer[i] = i;
            }
        }
    }
}
