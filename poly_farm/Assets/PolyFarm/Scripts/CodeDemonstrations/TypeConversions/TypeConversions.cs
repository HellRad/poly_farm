using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDemo.TypeConversions
{
    public class Animal { }
    public class Chicken : Animal { }

    public class TypeConversions
    {
        void ImplicitConversion()
        {
            int intVariable = 3;
            float floatVariable = intVariable;

            Chicken chicken = new Chicken();
            Animal anAnimal = chicken;
        }

        void ExpicitConversion()
        {
            Animal anAnimal = new Animal();
            Chicken chicken = (Chicken)anAnimal;
        }

        void ConversionWithHelperClass()
        {
            int someNumber = 42;
            string someText = someNumber.ToString();
        }    
    }
}
