using System;
using System.Linq;

namespace Test_B
{
    class Program
    {
        static void Main(string[] args)
        {
            var testsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < testsCount; i++)
            {
                var numbersCount = int.Parse(Console.ReadLine());
                var numbers = Console.ReadLine().Split(" ").Select(it => int.Parse(it)).ToArray();
                var pointer = new int[numbersCount];
                FillPointer(pointer);
                var niceImportance = new int[numbersCount];
                var nice = 1;

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
                        //дописать вариант когда вторые числа дублируются
                        else if (numbers[j - 1] == numbers[j] + 1)
                        {
                            counter++;
                            break;
                        }
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

        private static void PrintArray(int[] numbers)
        {
            foreach(int i in numbers)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public static void Sort(int[] array, int[] pointer)
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

        public static void FillPointer(int[] pointer)
        {
            for(int i = 0; i < pointer.Length; i++)
            {
                pointer[i] = i;
            }
        }
    }
}
