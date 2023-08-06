namespace sapir_c23_dn_course_itamar_and_uriel.Ex01_02
{

    public class HourglassPrinter
    {
        public static void Main()
        {
            const int k_HourglassHeight = 5;

            PrintHourglass(k_HourglassHeight);

        }

        public static void PrintHourglass(int i_RequestedHeight)
        {
            int inferredHeight = i_RequestedHeight + ((i_RequestedHeight + 1) % 2);

            PrintHourglass(inferredHeight, inferredHeight);
        }

        public static void PrintHourglass(int i_RowSize, int i_MaxRow)
        {
            if (i_RowSize > 2)
            {
                //Upper triangle 
                PrintSpaces((i_MaxRow - i_RowSize) / 2);
                PrintStars(i_RowSize);
                Console.WriteLine("");
    
                PrintHourglass(i_RowSize - 2, i_MaxRow);
                
                //Lower triangle 
                PrintSpaces((i_MaxRow - i_RowSize) / 2);
                PrintStars(i_RowSize);
                Console.WriteLine("");
            }
            else
            {
                PrintSpaces((i_MaxRow - i_RowSize) / 2);
                PrintStars(i_RowSize);
                Console.WriteLine("");
            }

        }

        public static void PrintSpaces(int i_count)
        {
            for (int i = 0; i < i_count; i++)
            {
                Console.Write(" ");
            }
        }

        public static void PrintStars(int i_count)
        {
            for (int i = 0; i < i_count; i++)
            {
                Console.Write("*");
            }
        }
    }
}

