using System.Text;
using sapir_c23_dn_course_gil_and_david;
namespace sapir_c23_dn_course_gil_and_david.Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            const int k_BufferSize = 50;

            Console.WriteLine("Please enter a 6 digits long number");
            string userInput = GetValidInput();

            StringBuilder numberInfo = new ("=== Number Data ===", k_BufferSize);
            numberInfo.Append(Environment.NewLine);
            numberInfo.Append(string.Format(
                "There are {0} digits that are greater than the units digit", CountDigitsThatAreGreaterThenTheUnitsDigit(userInput)));
            numberInfo.Append(Environment.NewLine);
            numberInfo.Append(string.Format("Minimum digit is {0}", FindMinimumDigit(userInput)));
            numberInfo.Append(Environment.NewLine);
            numberInfo.Append(string.Format("There are {0} digits that are divided by 3", GetDividedBy3Amount(userInput)));
            numberInfo.Append(Environment.NewLine);
            numberInfo.Append(string.Format("The digits average is {0}", GetDigitsAverage(userInput)));
            numberInfo.Append(Environment.NewLine);
            Console.WriteLine(numberInfo.ToString());
        }

        public static string GetValidInput()
        {
            bool valid;
            string input;

            do
            {
                input = Console.ReadLine() ??  "";
                valid = int.TryParse(input, out _) && input.Length == 6;

                if(!valid)
                {
                    Console.WriteLine("Invalid input. Please enter an integer with 6 digits.");
                }
            }
            while (!valid);

            return input;
        }

        public static int CountDigitsThatAreGreaterThenTheUnitsDigit(string i_NumberAsString)
        {
            int counter = 0;
            char unitsDigit = i_NumberAsString[^1];

            foreach(int digit in i_NumberAsString)
            {
                if( digit > unitsDigit)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static char FindMinimumDigit(string i_NumberAsString)
        {
            char minChar = '9';

            foreach(char digit in i_NumberAsString)
            {
                minChar = minChar < digit ? minChar : digit;
            }
            return minChar;
        }

        public static int GetDividedBy3Amount(string i_NumberAsString)
        {
            int dividedBy3Amount = 0;

            foreach (char digit in i_NumberAsString)
            {
                int parsedDigit = int.Parse(digit.ToString());
                if (parsedDigit % 3 == 0)
                {
                    dividedBy3Amount++;
                }
            }

            return dividedBy3Amount;
        }

        public static float GetDigitsAverage(string i_NumberAsString)
        {
            float average = 0;

            foreach (char digit in i_NumberAsString)
            {
                int ParsedDigit = int.Parse(digit.ToString());
                average += ParsedDigit;
            }

            average /= i_NumberAsString.Length;

            return average;
        }
    }
}