using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace zad1
{
    class Program
    {

        public class Class1
        {
            public static object Result { get; private set; }

            private static async Task LetsSayUserClickedAButtonOnGuiMethodAsync()
            {
                var result =await GetTheMagicNumberAsync();
                Console.WriteLine(result);
            }

            private static async Task<int> GetTheMagicNumberAsync()

            {
                return await IKnowIGuyWhoKnowsAGuyAsync();
            }

            private static async Task<int> IKnowIGuyWhoKnowsAGuyAsync()
            {
                return await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
            }

            private static async Task<int> IKnowWhoKnowsThisAsync(int n)
            {
                return await FactorialDigitSumAsync(n);
            }

            private static async Task<int> FactorialDigitSumAsync(int n)
            {
                
            var fakt = 1;
                var sum = 0;
                for (int i = 1; i <= n; i++)
                {
                    fakt*= i;
                }
                while (fakt != 0)
                {
                    sum+= fakt % 10;
                    fakt /= 10;
                }
                
                return sum;
            }

          
            static void Main(string[] args)
            {
                var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethodAsync());
                Console.Read();


            }

        }
    }
}






    

