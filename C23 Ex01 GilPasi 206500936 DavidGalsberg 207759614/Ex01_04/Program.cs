using System.Text;
namespace sapir_c23_dn_course_gil_and_david.Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a word or a number. It must be 8 characters long.");
            string userInput = GetValidInput();
            const int k_BufferSize = 50;
            bool is_palindrome = CheckIfPalindrome(userInput);

            StringBuilder stringInfo = new("=== String analysis ===", k_BufferSize);
            stringInfo.Append(Environment.NewLine);
            stringInfo.Append(string.Format("This string is a palindrome: {0}", CheckIfPalindrome(userInput)));
            stringInfo.Append(Environment.NewLine);

            if (int.TryParse(userInput, out int ParsedInput))
            {
                bool isDivisibleBy4 = ParsedInput % 4 == 0;
                stringInfo.Append(string.Format("This number is divisible by 4: {0} ", isDivisibleBy4));
            }
            else
            {
                int upperCaseAmount = userInput.Count(char.IsUpper);
                stringInfo.Append(string.Format("This word has {0} capital letters ", upperCaseAmount));
            }

            Console.WriteLine(stringInfo.ToString());

        }

        public static bool CheckIfPalindrome(string i_String)
        {
            int lastChar = i_String.Length - 1;
            bool isCharsFit = i_String[0] == i_String[lastChar];
            bool isEndOfString = i_String.Length == 2;
            bool isInnerStringPalindrome = true;
            if (!isEndOfString)
            {
                isInnerStringPalindrome = CheckIfPalindrome(i_String[1..lastChar]);
            }

            return isCharsFit && isInnerStringPalindrome;
        }

        public static string GetValidInput()
        {
            bool valid;
            string input;

            do
            {
                input = Console.ReadLine() ?? "";
                valid = CheckIfValidString(input);
                if (!valid)
                {
                    Console.WriteLine("Invalid input.The string must be letter only or digits only.{0}Also it must be 8 characters long.",
                        Environment.NewLine);
                }
            }
            while (!valid);

            return input;
        }

        public static bool CheckIfValidString(string i_str)
        {
            const int k_RequestedLength = 8;
            bool containsLetter = false;
            bool containsDigit = false;
            bool containsInvalidChars = false;

            foreach (char currentChar in i_str)
            {
                containsLetter = containsLetter || char.IsLetter(currentChar);
                containsDigit = containsDigit || char.IsDigit(currentChar);
                containsInvalidChars = containsInvalidChars || IsSpecialCharacter(currentChar);
            }

            bool isDigitsAndLetters = containsDigit && containsLetter;
            bool correctLength =  i_str.Length == k_RequestedLength;
            bool isValid = !containsInvalidChars && !isDigitsAndLetters && correctLength;
            return isValid;
        }

        public static bool IsSpecialCharacter(char i_Char) {

            return !char.IsDigit(i_Char) && !char.IsLetter(i_Char);
        }
    }
}