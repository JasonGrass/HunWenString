using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace HuiwenStr
{
    // 栈 管理
    static class StackMgr
    {

        public static string SrcString;
        public static string ResultString; // 最终的回文字符串

        private static Stack<StackNode> StrStack = new Stack<StackNode>();

        public static int MaxLength { private set; get; }

        public static int CurrentLength { private set; get; }

        public static void Clear()
        {
            StrStack.Clear();
            MaxLength = 0;
        }



        public static bool Push(StackNode node)
        {

            if (StrStack.ToArray().ToList().Find(n=> n.LowIndex == node.LowIndex || n.HighIndex == node.LowIndex) != null 
                &&
                StrStack.ToArray().ToList().Find(n => n.LowIndex == node.HighIndex || n.HighIndex == node.HighIndex) != null)
            {
                // 这个判断针对 axxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxa 这样的字符串有明显的速度提升效果，避免重复判断
                return false;
            }

            while (StrStack.Count > 0)
            {
                StackNode popNode = StrStack.Peek();
                if (!StackNode.IsInside(node, popNode))
                {
                    StrStack.Pop();
                }
                else
                {
                    break;
                }
            }
            StrStack.Push(node);
            StackPushed();

            return true;
        }


        private static void StackPushed()
        {
            // 记录最大长度
            CurrentLength = StrStack.Sum(node => node.Length);

            if (CurrentLength > MaxLength)
            {
                MaxLength = CurrentLength;

                StackNode[] nodes = StrStack.ToArray();                
                string result = string.Empty;
                for (int i = 0; i < nodes.Length; i++)
                {
                    StackNode node = nodes[i];
                    if (node.Length == 1)
                    {
                        result += SrcString[node.LowIndex];
                    }
                    else
                    {
                        result = SrcString[node.LowIndex] + result + SrcString[node.HighIndex];
                    }
                }
                //Console.WriteLine("中间结果：" + result);

                ResultString = result;

            }
        }


    }
}
