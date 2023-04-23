using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDemo.Delegates
{
    public class Chicken
    {
        public delegate void ThingsToDo(string text);

        public ThingsToDo ToDo;

        public void GatherThingsToDo()
        {
            ToDo = new ThingsToDo(Run);
            //or
            ToDo += BeCute;
            //or
            ToDo = (string text) => { SayThings(text); };
        }

        void BeCute(string purrText)
        { }

        void Run(string cryText)
        { }

        void SayThings(string text) { }
    }


    public class ChickenGodAI
    {
        Chicken chicken;

        void MakeChickenToThingsWhileSayingStuff(string text)
        {
            chicken.ToDo?.Invoke(text);
        }
    }
}
