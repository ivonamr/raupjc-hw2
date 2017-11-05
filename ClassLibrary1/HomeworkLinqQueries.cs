using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)

        {
            string[] array = new string[intArray.Length];
            var q =
                from s in intArray
                group s by s into sGroup
                orderby sGroup.Key
                select sGroup;

            foreach (var groupOfInt in q)
            {
                int i = 0;
                Console.WriteLine(groupOfInt.Key);
                foreach (var student in groupOfInt)
                {
                    i++;

                }
                array[groupOfInt.Key - 1] = string.Format("broj {0} ponavlja se {1} puta", groupOfInt.Key
                    , i);
            }
            return array;

        }



        public static University[] Linq2_1(University[] universityArray)

        {


            return universityArray.Where(s => s.Students.All(t => t.Gender.Equals(Gender.Male))).ToArray();

        }



        public static University[] Linq2_2(University[] universityArray)

        {

            double average = universityArray.Select(s => s.Students.Length).Average();
            return universityArray.Where(s => s.Students.Length < average).ToArray();

        }



        public static Student[] Linq2_3(University[] universityArray)

        {

            return universityArray.SelectMany(s => s.Students).Distinct().ToArray();

        }



        public static Student[] Linq2_4(University[] universityArray)

        {

            return universityArray.Where(s => s.Students.All(t => t.Gender.Equals(Gender.Male))
            || s.Students.All(t => t.Gender.Equals(Gender.Female))).SelectMany(z => z.Students).Distinct().ToArray();

        }



        public static Student[] Linq2_5(University[] universityArray)

        {
            return universityArray.SelectMany(s => s.Students).GroupBy(k => k).
                  ToDictionary(y => y.Key, y => y.Count()).Where(y => y.Value > 1).
                  Select(d => d.Key).ToArray();


        }

    }
}
