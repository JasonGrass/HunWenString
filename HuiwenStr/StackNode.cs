using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuiwenStr
{
    class StackNode
    {
        public StackNode(int lowIndex,int highIndex)
        {
            this.LowIndex = lowIndex;
            this.HighIndex = highIndex;
        }

        public int LowIndex { get; set; }

        public int HighIndex { get; set; }

        public int Length
        {
            get 
            {
                return LowIndex == HighIndex ? 1 : 2;
            }
        }

        // 判断 in 区间 是否在 out 区间 内
        public static bool IsInside(int inLow, int inHigh,int outLow,int outHigh)
        {
            return
                inLow > outLow &&
                inLow < outHigh &&
                inHigh > outLow &&
                inHigh < outHigh;
        }

        // 判断 inNode 是否 在 outNode 区间内
        public static bool IsInside(StackNode inNode, StackNode outNode)
        {
            return IsInside(inNode.LowIndex, inNode.HighIndex, outNode.LowIndex, outNode.HighIndex);
        }

    }
}
