using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6i7
{
    public class Class1
    {
        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static int GetTheMagicNumber()
       
        {
            return IKnowIGuyWhoKnowsAGuy();
        }
        private static int IKnowIGuyWhoKnowsAGuy()
        {
            return IKnowWhoKnowsThis(10) + IKnowWhoKnowsThis(5);
        }
        private static int IKnowWhoKnowsThis(int n)
        {
            return FactorialDigitSum(n).Result;
        }

        private static int FactorialDigitSum(int n)
        {
            return n;
        }

}
}
