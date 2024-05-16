using System;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стоимость товара в копейках (от 1 до 9999):");
            int sum = int.Parse(Console.ReadLine());

            string outMessage_01 = Logic.Lab1_01(sum);

            Console.WriteLine(outMessage_01);

            Console.WriteLine("Введите количество элементов в последовательности:");
            int count = int.Parse(Console.ReadLine());

            int[] sequence = new int[count];

            Console.WriteLine("Введите последовательность чисел:");
            for (int i = 0; i < count; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            if (sum < 1 || sum > 9999)
            {
                Console.WriteLine("Некорректное значение! Введите число от 1 до 9999.");
            }

            Console.WriteLine("Введите значение n:");
            int n = int.Parse(Console.ReadLine());

            string outMessage_02 = Logic.Lab1_02(count, sequence, n);

            Console.WriteLine(outMessage_02);

            Console.WriteLine("Введите первое слово:");
            string word1 = Console.ReadLine();

            Console.WriteLine("Введите второе слово:");
            string word2 = Console.ReadLine();

            Console.WriteLine("Результат:");

            string outMessage_03 = Logic.Lab1_03(word1, word2);
            Console.WriteLine(outMessage_03);
        }
    }

    public class Logic
    {
        public static string Lab1_01(int sum)
        {
            string outMessage = "";

            int rubles = sum / 100; 
            int kopecks = sum % 100;

            string rublesStr = "";
            if (rubles != 0)
            {
                if (rubles == 1)
                    rublesStr = $"{rubles} рубль ";
                else if (rubles <= 4)
                    rublesStr = $"{rubles} рубля ";
                else
                    rublesStr = $"{rubles} рублей ";
            }

            string kopecksStr = "";
            if (kopecks != 0)
            {
                if (kopecks == 1)
                    kopecksStr = $"{kopecks} копейка ";
                else if (kopecks <= 4)
                    kopecksStr = $"{kopecks} копейки ";
                else
                    kopecksStr = $"{kopecks} копеек ";
            }

            outMessage = $"Стоимость товара: {rublesStr}{kopecksStr}";

            return outMessage.Trim();
        }

        public static string Lab1_02(int count, int[] sequence, int n)
        {
            string outMessage = "";

            bool found = false;
            int index = -1;

            for (int i = 0; i < sequence.Length - n + 1; i++)
            {
                bool isEqual = true;
                for (int j = 1; j < n; j++)
                {
                    if (sequence[i + j] != sequence[i])
                    {
                        isEqual = false;
                        break;
                    }
                }

                if (isEqual)
                {
                    found = true;
                    index = i + 1;
                    break;
                }
            }

            if (found)
            {
                outMessage = $"В последовательности найдена {n}-ка одинаковых соседних чисел. Первая из таких пар находится на позиции {index}.";
            }
            else
            {
                outMessage = $"В последовательности нет {n}-ки одинаковых соседних чисел.";
            }
            return outMessage;
        }

        public static string Lab1_03(string word1, string word2)
        {
            string result = "";
            bool[] checkedLetters = new bool[26];

            word1 = word1.ToLower();
            word2 = word2.ToLower();

            foreach (char letter in word1)
            {
                if (!checkedLetters[letter - 'а'])
                {
                    if (word2.Contains(letter))
                    {
                        result += "да ";
                    }
                    else
                    {
                        result += "нет ";
                    }
                    checkedLetters[letter - 'а'] = true;
                }
            }
            return result.Trim();
        }
    }
}