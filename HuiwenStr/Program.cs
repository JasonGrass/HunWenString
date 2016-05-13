using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuiwenStr
{
    class Program
    {
        static void Main(string[] args)
        {

            // 复杂测试字符串：
            /* skdjfksdjfksdjfksjfjskljfklsjlkfslkjflsjlfjksdjfklsjdkfjksdjfksdjfklsdjlkfjslkdjflksdjflksdjflksdjflksdjf */

            while (true)
            {
                Console.WriteLine("Input string : ");
                string input = Console.ReadLine();

                if (input == null || input.Trim().Length == 0)
                {
                    continue;
                }

                StackMgr.SrcString = input;

                Console.WriteLine();

                Str str = new Str(input);

                str.FindHuiwenStr(0, input.Length - 1);

                Console.WriteLine("Result is : " + StackMgr.MaxLength);
                Console.WriteLine("the string is : \n\n" + StackMgr.ResultString + "\n");

                StackMgr.Clear();

                Console.WriteLine("----------------------------------------------------------------------------------------------------");
            }

        }


    }
}
