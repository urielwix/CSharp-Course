using System.Text;
namespace sapir_c23_dn_course_gil_and_david.Ex01_01
{
    class Program
    {
        static void Main()
        {
            const int k_InputSize = 7;
            const int k_UsersInputsCount = 3;
            float onesCount = 0;
            float zeroesCount = 0;
            int powersOf2Count = 0;
            int ascendingDecimalDigitsAmount = 0;
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            const int BufferMaxSize = 50;

            for (int i = 0; i < k_UsersInputsCount; i++)
            {
                string ValidInput = GetBinaryNumber(k_InputSize);
                int InputAsDecimal = BinaryToDecimal(ValidInput);
                Console.WriteLine(string.Format("Your number as a decimal is: {0}", InputAsDecimal));
                int onesInNumber = CountOnes(ValidInput);
                onesCount += onesInNumber;
                zeroesCount += k_InputSize - onesInNumber;
                if (CheckIfIsAPowerOf2(ValidInput))
                {
                    powersOf2Count++;
                }

                if(CheckIfIsAscendingSequence(InputAsDecimal))
                {
                    ascendingDecimalDigitsAmount++;
                }
                maxNumber = Max(maxNumber, InputAsDecimal);
                minNumber = Min(minNumber, InputAsDecimal);

            }

            onesCount /= k_UsersInputsCount;
            zeroesCount /= k_UsersInputsCount;
            StringBuilder Data = new("=== Data ===", BufferMaxSize);
            Data.Append(Environment.NewLine);
            Data.Append(string.Format("Zeroes Average : {0}", zeroesCount));
            Data.Append(Environment.NewLine);
            Data.Append(string.Format("Ones Average : {0}", onesCount));
            Data.Append(Environment.NewLine);
            Data.Append(string.Format("There are {0} numbers which are a power of 2", powersOf2Count));
            Data.Append(Environment.NewLine);
            Data.Append(string.Format("There are {0} numbers with ascending decimal representation ",
                ascendingDecimalDigitsAmount));
            Data.Append(Environment.NewLine);
            Data.Append(string.Format("The maximum number is {0} and the minimum number is {1}", maxNumber, minNumber));

            Console.Write(Data.ToString());
        }


        public static string GetBinaryNumber(int i_numberLength)
        {
            bool validInput;
            string userInput;

            do
            {
                Console.WriteLine(string.Format("Enter a {0} digits binary number", i_numberLength));
                userInput = Console.ReadLine() ?? "";

                validInput = CheckIfHasValidSize(userInput, i_numberLength) && CheckIfBinary(userInput);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            while (!validInput);

            return userInput;
        }

        public static bool CheckIfHasValidSize(string i_NumberAsString, int i_RequestedLength)
        {
            return i_NumberAsString.Length == i_RequestedLength;
        }

        public static bool CheckIfBinary(string i_NumberAsString)
        {
            bool isBinary = true;
            foreach (char digit in i_NumberAsString)
            {
                isBinary = digit == '0' || digit == '1';
                if (!isBinary) break;
            }

            return isBinary;
        }

        public static int BinaryToDecimal(string i_BinaryNumberString)
        {

            int decimalValue = 0;
            int power = 6;

            foreach (char digitChar in i_BinaryNumberString)
            {
                int digit = digitChar - '0';

                decimalValue += digit * (int)Math.Pow(2, power);
                power--;
            }

            return decimalValue;
        }

        public static int CountOnes(string i_BinaryString)
        {
            int counter = 0;

            for (int i = 0; i < i_BinaryString.Length; i++)
            {
                if (i_BinaryString[i] == '1')
                {
                    counter++;
                }
            }

            return counter;
        }

        public static bool CheckIfIsAPowerOf2(string i_BinaryNumber)
        {
            return CountOnes(i_BinaryNumber) == 1;
            // A power of 2 in binary format consists of only a single '1' digit.
        }

        public static bool CheckIfIsAscendingSequence(int i_Number)
        {
            bool result = true;
            string NumberAsString = i_Number.ToString();

            for (int i = 1; i < NumberAsString.Length && result; i++)
            {
                result = NumberAsString[i] > NumberAsString[i - 1];
            }

            return result;
        }

        public static int Max(int i_CurrentMax, int i_ExaminedValue)
        {
            return Math.Max(i_CurrentMax,i_ExaminedValue);
        }

        public static int Min(int i_CurrentMin, int i_ExaminedValue)
        {
            return Math.Min(i_CurrentMin, i_ExaminedValue);
        }
    }
}