using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuiwenStr
{
    class Str
    {
        // 原始字符串数据
        private readonly string strData;

        // 字符串编号
        private List<int> strNumbers = new List<int>();

        // 字符串数组
        private readonly List<char> charList = new List<char>();
        // 反转的字符串数组
        private readonly List<char> reCharList = new List<char>();

        public Str(string str)
        {
            this.strData = str;
          
            // 创建字符串数组
            foreach (char c in strData)
            {
                charList.Add(c);
                strNumbers.Add(0);
            }

            // 反转字符串
            string tmp = Reserve(strData);
            foreach (char c in tmp)
            {
                reCharList.Add(c);
            }

            CalcStrNumbers();

        }



        
        // 计算字符编号
        private void CalcStrNumbers()
        {
            int currentNum = 1;
            List<char> tmpList = new List<char>();

            foreach (char c in charList)
            {
                if (tmpList.Exists(ch => ch == c))
                {
                    continue;
                }

                int index = -1;

                while (index < charList.Count)
                {
                    index = charList.FindIndex(index+1, ch => ch == c);
                    if (index == -1)
                    {
                        break;
                    }
                    else
                    {
                        strNumbers[index] = currentNum;
                    }             
                }

                tmpList.Add(c);
                currentNum++;
            }
        }


  
        /// <summary>
        /// 迭代查找回文字符串
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public void FindHuiwenStr(int startIndex,int endIndex)
        {

            if (endIndex - startIndex + 1 + StackMgr.CurrentLength <= StackMgr.MaxLength)
            {
                return;
            }

            if (startIndex > endIndex)
            {
                return;
            }
            if (startIndex == endIndex)
            {
                StackNode node = new StackNode(startIndex,endIndex);
                StackMgr.Push(node);
                return;
            }


            for (int start = startIndex; start < endIndex; start++)
            {

                

                char currentChar = Next(start);
                int reCharIndex = ReNext(currentChar, endIndex);

                if (reCharIndex - start + 1 + StackMgr.CurrentLength <= StackMgr.MaxLength)
                {
                    return;
                }

                if (reCharIndex == start)
                {
                    StackNode node = new StackNode(start, reCharIndex);
                    StackMgr.Push(node);

                    continue;
                }
                else
                {
                    StackNode node = new StackNode(start, reCharIndex);
                    if (!StackMgr.Push(node))
                    {
                        return;
                    }

                    FindHuiwenStr(start + 1, reCharIndex - 1);
                }

            }

        }

        // 获取 索引 为 index 的字符
        private char Next(int index)
        {
            return charList[index];
        }

        // 在原字符串的基础上，从右起第 endIndex 开始向左数，字符 c 所在的索引，
        private int ReNext(char c,int endIndex)
        {
            return GetReserveIndex(reCharList.FindIndex(GetReserveIndex(endIndex), ch => ch == c));
        }


        // 反转字符串与实际字符串的下标对应关系
        private int GetReserveIndex(int index)
        {
            return strData.Length - index - 1;
        }

        // 反转字符串
        public static string Reserve(string str)
        {
            if (str.Length == 1)
            {
                return str;
            }
            else
            {
                return str[str.Length - 1] + Reserve(str.Substring(0,str.Length-1));
            }
        }

        // 打印字符串 
        public static void PrintStr(string str,int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
        }

    }
}
