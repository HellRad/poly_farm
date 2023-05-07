using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    //This is a "static class". This means the class exists only once in the entire game. You catch this class form anywhere in cour code using the proper name space
    public static class ChoresProgress 
    {
        public static bool StartedDay { get; set; } = true;
        public static bool PlayerInHurry { get;set; } = false;
    }
}
