using System.Text;
namespace sapir_c23_dn_course_itamar_and_uriel.Ex01_05
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
                "There are {0} digits that are greater than the units digit", GetDigitsGreaterThenUnitsDigitAmount(userInput)));
            numberInfo.Append(Environment.NewLine);
            numberInfo.Append(string.Format("Minimum digit is {0}", GetMinDigit(userInput)));
            numberInfo.Append(Environment.NewLine);
            numberInfo.Append(string.Format("There are {0} digits divided by 3", GetDividedBy3Amount(userInput)));
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

        public static int GetDigitsGreaterThenUnitsDigitAmount(string i_NumberAsString)
        {
            int DigitsGreaterThenUnitsDigitAmount = 0;
            char unitsDigit = i_NumberAsString[^1];

            foreach(char digit in i_NumberAsString)
            {
                if(digit > unitsDigit)
                {
                    DigitsGreaterThenUnitsDigitAmount++;
                }
            }

            return DigitsGreaterThenUnitsDigitAmount;
        }

        public static char GetMinDigit(string i_NumberAsString)
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
            int DividedBy3Amount = 0;

            foreach(char digit in i_NumberAsString)
            {
                int parsedDigit = int.Parse(digit.ToString());
                if (parsedDigit % 3 == 0)
                {
                    DividedBy3Amount++;
                }
            }

            return DividedBy3Amount;
        }

        public static float GetDigitsAverage(string i_NumberAsString)
        {
            float totalSum = 0;

            foreach(char digit in i_NumberAsString)
            {
                int ParsedDigit = int.Parse(digit.ToString());
                totalSum += ParsedDigit;
            }

            float average = totalSum / i_NumberAsString.Length;

            return average;
        }
    }
}