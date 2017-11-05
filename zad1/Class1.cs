using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)

        {

            if (!(obj is Student))

            {

                // Nothing to look here, obj isn't even of type "Product"!

                return false;

            }



            // If they have the same id, they are the same product.

            return this.Jmbag == ((Student) obj).Jmbag;

        }

        public override int GetHashCode()

        {

            // If two products are equal, they will have the same hash code.

            // Two products are equal if their ID matches, so the easiest way to do this is 

            // just to return the Id.GetHashCode(). 

            return Jmbag.GetHashCode();


        }
        public static bool operator ==(Student st1, Student st2)
        {
            if ((object)st1 == (object)st2) return true;
            if ((object)st1 == null) return false;
            if ((object)st2 == null) return false;
            return st1.Equals(st2);
        }
        public static bool operator !=(Student st1, Student st2)
        {
            return !(st1 == st2);
        }
    }

    public enum Gender
    {
        Male, Female
    }
  
}


