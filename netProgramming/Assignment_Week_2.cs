using System;
using System.Linq;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace netProgramming
{
    public class Assignment_Week_2
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("원하는 기능을 입력해주세요 (1~7에 해당하지 않는 문자열 및 숫자가 입력되면 프로그램은 종료됩니다.)\n");
                Console.Write("1.입력받은 숫자가 양수인지 음수인지 0인지 판단하기\n");
                Console.Write("2.문자열에서 모음의 개수를 세어 출력하는 프로그램\n");
                Console.Write("3.입력받은 숫자들 중 중복되지 않은 숫자만을 출력\n");
                Console.Write("4.문자열에서 가장 많은 단어 출력하기\n");
                Console.Write("5.입력받은 숫자를 오름차순으로 정렬하는 프로그램\n");
                Console.Write("6.숫자를 제외한 모든 문자를 대문자로 바꾸는 프로그램\n");
                Console.Write("7.입력받은 숫자를 이진수로 변환해서 출력하는 프로그램\n");

                switch (CheckCorrectInput())
                {
                    case 1:
                        CheckPosNegZero();
                        break;
                    case 2:
                        CntVowel();
                        break;
                    case 3:
                        Duplication();
                        break;
                    case 4:
                        HighFreqency();
                        break;
                    case 5:
                        Sort();
                        break;
                    case 6:
                        UpperString();
                        break;
                    case 7:
                        ConvertByte();
                        break;
                    case -1:
                        Console.Write("프로그램을 종료합니다.");
                        return;
                }
            }
        }


        public static void CheckPosNegZero()
        {
            try
            {
                Console.Write("숫자를 입력하세요: ");
                long num = long.Parse(Console.ReadLine());

                string result = num > 0 ? "양수" : num < 0 ? "음수" : "0";
                Console.WriteLine("입력하신 숫자는 {0}입니다.", result);
            }
            catch (FormatException)
            {
                Console.WriteLine("잘못된 형식의 숫자를 입력하셨습니다.");
            }
        }

        public static void CntVowel()
        {
            Console.Write("문자열을 입력하세요: ");
            string input = Console.ReadLine();

            Func<char, bool> isVowel = c => "aeiou".Contains(char.ToLower(c));
            int vowelCount = input.Count(isVowel);

            Console.WriteLine($"문자열 '{input}'에서 모음의 개수는 {vowelCount}개입니다.");
        }

        public static void Sort()
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("숫자를 입력하세요 (종료: 빈 줄): ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int number;
                try
                {
                    number = int.Parse(input);
                }
                catch (Exception) { Console.WriteLine("올바르지 않은 숫자가 입력되었습니다."); return; }
                numbers.Add(number);
            }
            numbers.Sort();
            Console.WriteLine("정렬된 배열 : " + string.Join(" ", numbers));
        }
        public static void UpperString()
        {
            Console.Write("문자열을 입력하세요: ");
            string input = Console.ReadLine();

            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    output += input[i];
                }
                else
                {
                    output += char.ToUpper(input[i]);
                }
            }

            Console.WriteLine("결과: " + output);
        }
        public static int CheckCorrectInput()
        {
            string input = Console.ReadLine();
            int number;
            if (int.TryParse(input, out number))
            {
                switch (number)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
                    case 3:
                        return 3;
                    case 4:
                        return 4;
                    case 5:
                        return 5;
                    case 6:
                        return 6;
                    case 7:
                        return 7;
                }
            }
            return -1;
        }
        public static void ConvertByte()
        {
            Console.Write("이진수로 변환할 문자열을 입력하세요: ");
            string input = Console.ReadLine();

            // 입력받은 문자열을 byte 배열로 변환
            string strs = Convert.ToString(long.Parse(input), 2); ;

            // byte 배열의 각 요소를 이진수로 변환하여 출력
            Console.Write("해당 숫자의 이진수는 " + strs + "입니다.");

        }
        static void HighFreqency()
        {
            Console.Write("문자열을 입력하세요: ");
            string input = Console.ReadLine();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            // 문자열의 각 문자를 카운팅하여 dictionary에 저장
            foreach (char c in input)
            {
                if (dictionary.ContainsKey(c))
                {
                    dictionary[c]++;
                }
                else
                {
                    dictionary.Add(c, 1);
                }
            }

            char maxChar = ' ';
            int maxCount = 0;

            // dictionary에서 가장 많이 나온 문자 검색
            foreach (KeyValuePair<char, int> kvp in dictionary)
            {
                if (kvp.Value > maxCount)
                {
                    maxChar = kvp.Key;
                    maxCount = kvp.Value;
                }
            }

            Console.WriteLine($"가장 많이 나온 문자는 '{maxChar} 입니다.");
        }

        public static void Duplication()
        {
            Console.Write("숫자들을 입력하세요 (숫자와 숫자 사이에는 공백을 넣어주세요): ");
            string input = Console.ReadLine();
            int[] numbers = {};
            try
            {
                numbers = input.Split().Select(int.Parse).ToArray();
            }
            catch (Exception) { Console.WriteLine("올바르지 않은 숫자가 입력되었습니다."); return; }


            HashSet<int> uniqueNumbers = new HashSet<int>();
            foreach (int number in numbers)
            {

                if (uniqueNumbers.Contains(number))
                {
                    uniqueNumbers.Remove(number);
                }
                else
                {
                    uniqueNumbers.Add(number);
                }
            }

            Console.WriteLine("중복되지 않은 숫자들:");
            foreach (int number in uniqueNumbers)
            {
                Console.Write(number + " ");
            }
        }
    }
    
}

